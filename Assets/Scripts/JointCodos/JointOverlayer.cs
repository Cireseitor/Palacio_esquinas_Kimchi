using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
//using Windows.Kinect;

public class JointOverlayer : MonoBehaviour
{

    [Tooltip("Smooth factor used for hat-model rotation.")]
    public float smoothFactorRotation = 10f;

    [Tooltip("Smooth factor used for hat-model movement.")]
    public float smoothFactorMovement = 0f;
    public Player[] players;
    public GameObject contador, reposo;
    public Transform marcos;
    private float _time = 0;
    private int indexImage = 0;
    private FacetrackingManager faceManager;
    //[Tooltip("Camera that will be used to overlay the 3D-objects over the background.")]
    private Camera foregroundCamera;
    private long IdControlador = -1, numID;
    private bool tracked = false;
    // [Tooltip("Vertical offset of the hat above the head position (in meters).")]
    //public float verticalOffset = 0f;
    [Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
    public int playerIndex = 0;
    public int experiencia = 0;
    // [Tooltip("Kinect joint that is going to be overlayed.")]
    // public KinectInterop.JointType trackedJoint = KinectInterop.JointType.HandRight;
    private int iJointIndex;
    [Tooltip("Game object used to overlay the joint.")]
    public Transform overlayObject;
    public static KinectManager manager;
    //public float smoothFactor = 10f;
    Dictionary<Player, float> dictionary = new Dictionary<Player, float>();
    public Transform objetosCara;
    //public Text debugText;
    private Quaternion initialRotation = Quaternion.identity;
    private bool suffled = false;
    public PostProcessProfile[] post;
    private PostProcessVolume postProcessVolume;
    public static JointOverlayer instance;
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private float fadeDuration = 0.2f;
    [Header("Ajuste dinámico de resolución")]
    public float xPositionScale = 1f;

    void Start()
    {

        float referenceAspect = 16f / 9f; // ≈1.777
        float currentAspect = (float)Screen.width / (float)Screen.height;

        xPositionScale = referenceAspect / currentAspect;



        manager = KinectManager.Instance;
        foregroundCamera = Camera.main;
        instance = this;
        audioSource = GetComponent<AudioSource>();
        postProcessVolume = foregroundCamera.GetComponent<PostProcessVolume>();
        faceManager = gameObject.GetComponent<FacetrackingManager>();

        if (overlayObject)
        {
            overlayObject.rotation = Quaternion.identity;
        }

        marcosetter();
    }


    public void experience_behaviour(int value)
    {
        experiencia = value;


        //StartCoroutine(FadeOutIn(audioClips[experiencia]));
        postprocesschanger();
        marcosetter();
    }

    private IEnumerator FadeOutIn(AudioClip newClip)
    {
        float initialVolume = audioSource.volume;

        // Fade out
        for (float t = 0; t <= fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(initialVolume, 0, t / fadeDuration);
            yield return null;
        }
        audioSource.volume = 0;

        // Change clip and play
        audioSource.clip = newClip;
        audioSource.Play();

        // Fade in
        for (float t = 0; t <= fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, 1, t / fadeDuration);
            yield return null;
        }
        audioSource.volume = 1;
    }

    private void postprocesschanger()
    {
        postProcessVolume.profile = post[experiencia];
    }
    private void marcosetter()
    {
        // foreach (Transform t in marcos)
        // {
        //     t.gameObject.SetActive(false);
        // }

        // marcos.GetChild(experiencia).gameObject.SetActive(true);
    }
    private void ShufflePlayerIds()
    {
        List<int> availableIds = Enumerable.Range(0, players.Length).ToList(); // Crear lista de IDs disponibles
        //ShuffleList(availableIds); // Barajar la lista de IDs

        for (int i = 0; i < players.Length; i++)
        {
            players[i].id = availableIds[i]; // Asignar ID barajado
        }

    }

    private void ShuffleList(List<int> list)
    {
        int n = list.Count;
        System.Random random = new System.Random();
        while (n > 1)
        {
            int k = random.Next(n--);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    void Update()
    {
        //manager.refreshAvatarControllers();
        if (manager && manager.IsInitialized() && foregroundCamera)
        {
            Rect backgroundRect = foregroundCamera.pixelRect;
            PortraitBackground portraitBack = PortraitBackground.Instance;

            if (portraitBack && portraitBack.enabled)
            {
                backgroundRect = portraitBack.GetBackgroundRect();
            }

            //USER Detectado
            if (manager.IsUserDetected())
            {
                if (_time != 0)
                {
                    _time = 0;
                }

                if (!suffled)
                {
                    ShufflePlayerIds();
                    suffled = true;
                    // Notificar al CMS que se detectó un usuario
                    NotifyCmsManagerReposoChanged();
                }

                if (!manager.IsUserTracked(numID))
                {
                    foreach (Player player2 in players)
                    {
                        long userId = manager.GetUserIdByIndex(player2.id);
                        if (manager.IsUserTracked(userId))
                        {
                            numID = userId;
                            break;
                        }
                    }
                }

                suffled = true;
                if (reposo.activeSelf)
                {
                    reposo.SetActive(false);
                    NotifyCmsManagerReposoChanged();
                }
                //if (!marcos.gameObject.activeSelf) marcos.gameObject.SetActive(true);

                foreach (Player player in players)
                {
                    long userId = manager.GetUserIdByIndex(player.id);
                    if (!manager.IsUserTracked(userId))
                    {
                        // Desactiva individualmente elementos de este player
                        if (player.ManoIzquierda != null)
                            player.ManoIzquierda.SetActive(false);

                        if (player.ManoDerecha != null)
                            player.ManoDerecha.SetActive(false);

                        if (player.Cabeza[experiencia] != null)
                            player.Cabeza[experiencia].SetActive(false);

                        if (player.Torus != null)
                            player.Torus.transform.position = new Vector3(0, -2, 0);

                        continue; // Saltar al siguiente player
                    }
                    if (!tracked && userId == numID)
                    {
                        IdControlador = userId;

                        //CONTROL MANO PADRE
                        tracked = true;
                    }


                    iJointIndex = (int)KinectInterop.JointType.HandLeft;
                    if (player.ManoIzquierda != null)
                    {
                        if (manager.IsJointTracked(userId, iJointIndex))
                        {
                            if (player.ManoIzquierda.transform.childCount > 0)
                            {
                                foreach (Transform child in player.ManoIzquierda.transform)
                                {
                                    if (child.GetSiblingIndex() != experiencia)
                                    {
                                        child.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        child.gameObject.SetActive(true);
                                    }
                                }

                                player.ManoIzquierda.SetActive(true);

                                if (experiencia == 1 && player.Torus != null)
                                {
                                    if (!player.Torus.transform.parent.gameObject.activeSelf)
                                    {
                                        player.Torus.transform.parent.gameObject.SetActive(true);
                                    }

                                    // Obtén la posición de ManoIzquierda en coordenadas de pantalla
                                    Vector3 manoScreenPos = Camera.main.WorldToScreenPoint(player.ManoIzquierda.transform.position);

                                    // Calcula el porcentaje horizontal (0 a 1)
                                    float porcentajeX = manoScreenPos.x / Screen.width;

                                    // Rotación según posición en la pantalla
                                    float rotacionY;

                                    if (porcentajeX < 0.5f) // Si está a la izquierda de la pantalla
                                    {
                                        rotacionY = Mathf.Lerp(120, 0, porcentajeX * 2); // De 90 grados a 0 a medida que se acerca al centro
                                    }
                                    else // Si está a la derecha de la pantalla
                                    {
                                        rotacionY = Mathf.Lerp(0, -120, (porcentajeX - 0.5f) * 2); // De 0 a -90 grados hacia la derecha
                                    }

                                    // Ajusta la posición y rotación de Torus
                                    player.Torus.transform.position = new Vector3(player.ManoIzquierda.transform.position.x, player.ManoIzquierda.transform.position.y, player.ManoIzquierda.transform.position.z + 0.25f);
                                    player.Torus.transform.rotation = Quaternion.Euler(0, 90 + rotacionY, 0); // Aplica la rotación en el eje Y
                                }
                                // else if (experiencia != 1 && player.Torus != null)
                                // {
                                //     player.Torus.transform.parent.gameObject.SetActive(false);
                                // }
                                else if (experiencia != 1 && player.Torus != null)
                                {
                                    player.Torus.transform.position = new Vector3(0, -2, 0);
                                }


                            }

                            overlayObject = player.ManoIzquierda.transform;
                            Vector3 posJoint = manager.GetJointPosColorOverlay(userId, iJointIndex, foregroundCamera, backgroundRect);
                            if (posJoint != Vector3.zero)
                            {
                                if (overlayObject)
                                {
                                    overlayObject.position = new Vector3(posJoint.x * xPositionScale, posJoint.y, posJoint.z);
                                }
                            }
                        }
                        else
                        {
                            foreach (Transform child in player.ManoIzquierda.transform)
                            {
                                // child.gameObject.SetActive(false);
                            }
                            if (player.Torus != null)
                            {
                                player.Torus.transform.position = new Vector3(0, -2, 0);
                            }
                        }
                    }
                    //MANO DERECHA
                    iJointIndex = (int)KinectInterop.JointType.HandRight;
                    if (player.ManoDerecha != null)
                    {
                        if (manager.IsJointTracked(userId, iJointIndex))
                        {
                            if (player.ManoDerecha.transform.childCount > 0)
                            {
                                foreach (Transform child in player.ManoDerecha.transform)
                                {
                                    if (child.GetSiblingIndex() != experiencia)
                                    {
                                        child.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        child.gameObject.SetActive(true);
                                    }
                                }

                                player.ManoDerecha.SetActive(true);

                            }

                            overlayObject = player.ManoDerecha.transform;
                            Vector3 posJoint = manager.GetJointPosColorOverlay(userId, iJointIndex, foregroundCamera, backgroundRect);
                            if (posJoint != Vector3.zero)
                            {
                                if (overlayObject)
                                {
                                    overlayObject.position = new Vector3(posJoint.x * xPositionScale, posJoint.y, posJoint.z);
                                }
                            }
                        }
                        else
                        {
                            foreach (Transform child in player.ManoDerecha.transform)
                            {
                                // child.gameObject.SetActive(false);
                            }
                        }
                    }

                    iJointIndex = (int)KinectInterop.JointType.Head;
                    if (player.Cabeza[experiencia] != null)
                    {
                        for (int i = 0; i < objetosCara.childCount; i++)
                        {
                            if (i != experiencia)
                            {
                                objetosCara.GetChild(i).gameObject.SetActive(false);
                            }
                            else
                            {
                                objetosCara.GetChild(i).gameObject.SetActive(true);
                            }
                        }
                        if (manager.IsJointTracked(userId, iJointIndex))
                        {
                            player.Cabeza[experiencia].SetActive(true);
                            overlayObject = player.Cabeza[experiencia].transform;
                            Vector3 posJoint = manager.GetJointPosColorOverlay(userId, iJointIndex, foregroundCamera, backgroundRect);
                            if (posJoint != Vector3.zero)
                            {
                                if (overlayObject)
                                {
                                    Vector3 newPosition = faceManager.GetHeadPosition(userId, false);
                                    Quaternion newRotation, ultimaRotacion;

                                    newRotation = initialRotation * faceManager.GetHeadRotation(userId, false);

                                    Vector3 addedRotation = newPosition.z != 0f ? new Vector3(Mathf.Rad2Deg * (Mathf.Tan(newPosition.y) / newPosition.z),
                                        Mathf.Rad2Deg * (Mathf.Tan(newPosition.x) / newPosition.z), 0) : Vector3.zero;

                                    addedRotation.x = newRotation.eulerAngles.x + addedRotation.x;
                                    addedRotation.y = newRotation.eulerAngles.y + addedRotation.y;
                                    addedRotation.z = newRotation.eulerAngles.z + addedRotation.z;

                                    newRotation = Quaternion.Euler(-addedRotation.x + (newPosition.y * 150 / newPosition.z), -addedRotation.y, addedRotation.z);
                                    // end of rotational fix

                                    overlayObject.rotation = Quaternion.Slerp(overlayObject.rotation, newRotation, smoothFactorRotation * Time.deltaTime);
                                    ultimaRotacion = overlayObject.rotation;
                                    // model position
                                    newPosition = manager.GetJointPosColorOverlay(userId, (int)KinectInterop.JointType.Head, foregroundCamera, backgroundRect);
                                    if (newPosition == Vector3.zero)
                                    {
                                        // hide the model behind the camera
                                        newPosition.z = -10f;
                                    }

                                    // Escalar X según resolución (igual que las manos)
                                    newPosition = new Vector3(newPosition.x * xPositionScale, newPosition.y, newPosition.z);

                                    if (smoothFactorMovement != 0f && overlayObject.position.z >= 0f)
                                        overlayObject.position = Vector3.Lerp(overlayObject.position, newPosition, smoothFactorMovement * Time.deltaTime);
                                    else
                                        overlayObject.position = newPosition;

                                }
                            }
                        }
                        else
                        {
                            player.Cabeza[experiencia].SetActive(false);
                        }
                    }
                }


                tracked = false;
            }
            else
            {
                foreach (Player player in players)
                {
                    if (player.ManoDerecha != null)
                    {
                        player.ManoDerecha.SetActive(false);
                    }
                    if (player.ManoIzquierda != null)
                    {
                        //player.ManoIzquierda.SetActive(false);
                        player.ManoIzquierda.SetActive(false);

                    }

                    if (player.Cabeza[experiencia] != null)
                    {
                        player.Cabeza[experiencia].SetActive(false);
                    }
                }

                if (!reposo.activeSelf && _time > 5)
                {
                    reposo.SetActive(true);
                    NotifyCmsManagerReposoChanged();
                    // marcos.gameObject.SetActive(false);
                }
                else if (!reposo.activeSelf)
                {
                    _time += Time.deltaTime * 1;
                }
            }
        }
    }

    private void NotifyCmsManagerReposoChanged()
    {
        if (CmsManager.instance != null)
        {
            CmsManager.instance.OnReposoStateChanged();
        }
    }

    void OclusionL(long userId, Transform overlayObject)
    {
        if (manager.GetLeftHandState(userId).ToString() != "NotTracked" && manager.GetLeftHandState(userId).ToString() == "Closed")
        {
            foreach (Transform child in overlayObject)
            {
                if (child.name == "Oclusion")
                {
                    //overlayObject.gameObject.SetActive(true);
                    child.gameObject.SetActive(true);
                }
                if (child.name == "Particles")
                {
                    ParticleSystem ps = child.GetComponent<ParticleSystem>();
                    var em = ps.emission;
                    em.enabled = true;
                }
            }
        }
        else
        {
            foreach (Transform child in overlayObject)
            {
                if (child.name == "Oclusion")
                {
                    child.gameObject.SetActive(false);
                }
                if (child.name == "Particles")
                {
                    ParticleSystem ps = child.GetComponent<ParticleSystem>();
                    var em = ps.emission;
                    em.enabled = false;
                }
            }
        }
    }
}