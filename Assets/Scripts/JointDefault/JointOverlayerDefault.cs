//using UnityEngine;
//using System.Collections;
//using System.Linq;
//using System.Collections.Generic;
//using System;
//using UnityEngine.UI;
////using Windows.Kinect;

//public class JointOverlayerDefault : MonoBehaviour
//{

//    [Tooltip("Smooth factor used for hat-model rotation.")]
//    public float smoothFactorRotation = 10f;

//    [Tooltip("Smooth factor used for hat-model movement.")]
//    public float smoothFactorMovement = 0f;
//    public Player[] players;
//    public GameObject panelPreDet, contador;
//    public bool Halloween;
//    private float _time = 0;
//    private int indexImage = 0;
//    private FacetrackingManager faceManager;
//    //[Tooltip("Camera that will be used to overlay the 3D-objects over the background.")]
//    private Camera foregroundCamera;
//    private long IdControlador = -1, numID;
//    private bool tracked = false;
//    // [Tooltip("Vertical offset of the hat above the head position (in meters).")]
//    //public float verticalOffset = 0f;
//    [Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
//    public int playerIndex = 0;
//    public Transform fotoBoton;
//    public GameObject ManoControl;
//    // [Tooltip("Kinect joint that is going to be overlayed.")]
//    // public KinectInterop.JointType trackedJoint = KinectInterop.JointType.HandRight;
//    private int iJointIndex;
//    [Tooltip("Game object used to overlay the joint.")]
//    public Transform overlayObject, FocusDistance, HalloweenGirafa;
//    public static KinectManager manager;
//    //public float smoothFactor = 10f;
//    Dictionary<Player, float> dictionary = new Dictionary<Player, float>();

//    //public Text debugText;

//    private Quaternion initialRotation = Quaternion.identity;

//    void Start()
//    {
//        /* if (!PlayerPrefs.HasKey("Control") && PlayerPrefs.GetString("Control") != "qoakzm5674382901nhvdf*?�!�?��$)")
//         {
// 
//         } */
//        manager = KinectManager.Instance;
//        foregroundCamera = Camera.main;
//        faceManager = gameObject.GetComponent<FacetrackingManager>();
//        if (overlayObject)
//        {
//            // always mirrored
//            //initialRotation = Quaternion.Euler(new Vector3(180f, 0, 0f));
//            //initialRotation = transform.rotation;
//            overlayObject.rotation = Quaternion.identity;
//        }
//    }

//    void Update()
//    {
//        //manager.refreshAvatarControllers();
//        if (manager && manager.IsInitialized() && foregroundCamera)
//        {
//            Rect backgroundRect = foregroundCamera.pixelRect;
//            PortraitBackground portraitBack = PortraitBackground.Instance;

//            if (portraitBack && portraitBack.enabled)
//            {
//                backgroundRect = portraitBack.GetBackgroundRect();
//            }

//            //USER Detectado
//            if (manager.IsUserDetected())
//            {
//                if (!manager.IsUserTracked(numID))
//                {
//                    foreach (Player player2 in players)
//                    {
//                        long userId = manager.GetUserIdByIndex(player2.id);
//                        if (manager.IsUserTracked(userId))
//                        {
//                            numID = userId;
//                            break;
//                        }
//                    }
//                }
//                if (HandCollision._estado == 0)
//                {
//                    if (contador.activeSelf)
//                    {
//                        fotoBoton.gameObject.SetActive(false);
//                    }
//                    else
//                    {
//                        fotoBoton.gameObject.SetActive(true);
//                    }
//                }
//                else
//                {
//                    if (fotoBoton.GetChild(0).GetComponent<Image>().fillAmount > 0)
//                    {
//                        fotoBoton.GetChild(0).GetComponent<Image>().fillAmount = 0;
//                    }
//                }

//                panelPreDet.SetActive(false);
//                if (Halloween)
//                {
//                    HalloweenGirafa.localScale = new Vector3(0.1140961f, 0.1140961f, 0.1140961f);
//                }
//                foreach (Player player in players)
//                {
//                    long userId = manager.GetUserIdByIndex(player.id);
//                    if (!tracked && userId == numID)
//                    {
//                        IdControlador = userId;

//                        //CONTROL MANO PADRE
//                        // ManoControl.transform.SetParent(player.ManoIzquierda.transform);
//                        //ManoControl.transform.localPosition = Vector3.zero;
//                        tracked = true;
//                    }
//                    //MANO DERECHA
//                    iJointIndex = (int)KinectInterop.JointType.HandRight;
//                    if (manager.IsJointTracked(userId, iJointIndex))
//                    {
//                        player.ManoDerecha.SetActive(true);
//                        if (HandCollision._estado == 1 || HandCollision._estado == 2)
//                        {
//                            player.ManoDerecha.transform.GetChild(0).gameObject.SetActive(false);
//                        }
//                        else
//                        {
//                            player.ManoDerecha.transform.GetChild(0).gameObject.SetActive(true);
//                        }
//                        overlayObject = player.ManoDerecha.transform;
//                        Vector3 posJoint = manager.GetJointPosColorOverlay(userId, iJointIndex, foregroundCamera, backgroundRect);
//                        if (posJoint != Vector3.zero)
//                        {
//                            if (overlayObject)
//                            {
//                                overlayObject.position = new Vector3(posJoint.x, posJoint.y, posJoint.z);
//                                if (HandCollision._estado == 1 || HandCollision._estado == 2)
//                                {
//                                    /*  if (manoControlIzq.transform.parent != player.ManoDerecha) {
//                                          manoControlIzq.SetActive(true);
//                                      }

//                                      if (IdControlador == userId) {
//                                          manoControlIzq.transform.SetParent(player.ManoDerecha.transform);
//                                          manoControlIzq.transform.localPosition = Vector3.zero;
//                                      }*/

//                                }

//                                //overlayObject.localScale = new Vector3((2 - posJoint.z) / 100, (2 - posJoint.z) / 100, 0.2f);
//                                OclusionR(userId, overlayObject);

//                                /*if (manager.GetBodyHandData == InteractionManager.HandEventType.Grip) {
//                                    /* Quaternion rotJoint = manager.GetJointOrientation(userId, iJointIndex, false);
//                                     rotJoint = initialRotation * rotJoint;
//                                     overlayObject.rotation = rotJoint;*/
//                            }
//                        }
//                    }

//                    //MANO IZQUIERDA
//                    iJointIndex = (int)KinectInterop.JointType.HandLeft;
//                    if (manager.IsJointTracked(userId, iJointIndex))
//                    {
//                        /*if (IdControlador == userId) {

//                        }*/
//                        //dictionary.Add(player, Vector3.Distance(new Vector3(player.ManoIzquierda.transform.position.x, 0,0), fotoBoton.position));
//                        if (HandCollision._estado == 0)
//                        {
//                            player.ManoIzquierda.SetActive(true);

//                            if (player.ManoIzquierda.transform.childCount == 1)
//                            {
//                                player.ManoIzquierda.transform.GetChild(0).gameObject.SetActive(true);
//                            }
//                            else if (player.ManoIzquierda.transform.childCount > 1 && player.ManoIzquierda.transform.GetChild(1).name == "Mano")
//                            {
//                                player.ManoIzquierda.transform.GetChild(0).gameObject.SetActive(false);
//                            }
//                        }
//                        else if (player.ManoIzquierda.transform.childCount > 1 && player.ManoIzquierda.transform.GetChild(1).name == "Mano")
//                        {
//                            player.ManoIzquierda.transform.GetChild(0).gameObject.SetActive(false);
//                            player.ManoIzquierda.SetActive(true);
//                        }
//                        else if (player.ManoIzquierda.transform.childCount == 1 && HandCollision._estado == 1 || HandCollision._estado == 2)
//                        {
//                            player.ManoIzquierda.transform.GetChild(0).gameObject.SetActive(false);
//                            player.ManoIzquierda.SetActive(true);
//                        }
//                        overlayObject = player.ManoIzquierda.transform;
//                        Vector3 posJoint = manager.GetJointPosColorOverlay(userId, iJointIndex, foregroundCamera, backgroundRect);
//                        if (posJoint != Vector3.zero)
//                        {
//                            if (overlayObject)
//                            {
//                                overlayObject.position = new Vector3(posJoint.x, posJoint.y, posJoint.z);
//                                //overlayObject.localScale = new Vector3((2 - posJoint.z) / 100, (2 - posJoint.z) / 100, 0.2f);
//                                OclusionL(userId, overlayObject);
//                                /*Quaternion rotJoint = manager.GetJointOrientation(userId, iJointIndex, false);
//                                rotJoint = initialRotation * rotJoint;
//                                overlayObject.rotation = rotJoint;*/
//                            }
//                        }
//                    }
//                    else
//                    {
//                        player.ManoIzquierda.transform.localPosition = new Vector3(1000, 0, 0);
//                    }

//                    iJointIndex = (int)KinectInterop.JointType.Head;
//                    if (manager.IsJointTracked(userId, iJointIndex))
//                    {
//                        if (HandCollision._estado == 0)
//                            player.Cabeza.SetActive(true);
//                        else
//                            player.Cabeza.SetActive(false);
//                        overlayObject = player.Cabeza.transform;
//                        Vector3 posJoint = manager.GetJointPosColorOverlay(userId, iJointIndex, foregroundCamera, backgroundRect);
//                        if (posJoint != Vector3.zero)
//                        {
//                            if (overlayObject)
//                            {
//                                Vector3 newPosition = faceManager.GetHeadPosition(userId, false);
//                                Quaternion newRotation, ultimaRotacion;

//                                newRotation = initialRotation * faceManager.GetHeadRotation(userId, false);

//                                Vector3 addedRotation = newPosition.z != 0f ? new Vector3(Mathf.Rad2Deg * (Mathf.Tan(newPosition.y) / newPosition.z),
//                                    Mathf.Rad2Deg * (Mathf.Tan(newPosition.x) / newPosition.z), 0) : Vector3.zero;

//                                addedRotation.x = newRotation.eulerAngles.x + addedRotation.x;
//                                addedRotation.y = newRotation.eulerAngles.y + addedRotation.y;
//                                addedRotation.z = newRotation.eulerAngles.z + addedRotation.z;

//                                newRotation = Quaternion.Euler(-addedRotation.x + (newPosition.y * 150 / newPosition.z), -addedRotation.y, addedRotation.z);
//                                // end of rotational fix

//                                overlayObject.rotation = Quaternion.Slerp(overlayObject.rotation, newRotation, smoothFactorRotation * Time.deltaTime);
//                                ultimaRotacion = overlayObject.rotation;
//                                // model position
//                                newPosition = manager.GetJointPosColorOverlay(userId, (int)KinectInterop.JointType.Head, foregroundCamera, backgroundRect);
//                                if (newPosition == Vector3.zero)
//                                {
//                                    // hide the model behind the camera
//                                    newPosition.z = -10f;
//                                }

//                                /*                                if (verticalOffset != 0f) {
//                                                                    // add the vertical offset
//                                                                    Vector3 dirHead = new Vector3(0, verticalOffset, 0);
//                                                                    dirHead = overlayObject.InverseTransformDirection(dirHead);
//                                                                    newPosition += dirHead;
//                                                                }*/
//                                //newPosition = new Vector3(newPosition.x, newPosition.y+(posJoint.z /100), newPosition.z);
//                                // go to the new position
//                                if (smoothFactorMovement != 0f && overlayObject.position.z >= 0f)
//                                    overlayObject.position = Vector3.Lerp(overlayObject.position, newPosition, smoothFactorMovement * Time.deltaTime);
//                                else
//                                    overlayObject.position = newPosition;
//                                //overlayObject.localScale = new Vector3((3 - posJoint.z * 0.7f), (3 - posJoint.z * 0.7f), (3 - posJoint.z * 0.7f));
//                            }
//                        }
//                    }
//                    else
//                    {
//                        player.Cabeza.SetActive(false);
//                    }

//                    /*var cinturar = (int)KinectInterop.JointType.SpineBase;
//                    var cintural = (int)KinectInterop.JointType.SpineBase; */
//                    //CINTURA
//                    iJointIndex = (int)KinectInterop.JointType.SpineBase;

//                    if (manager.IsJointTracked(userId, iJointIndex))
//                    {
//                        if (HandCollision._estado == 0)
//                            player.Cintura.SetActive(true);
//                        else
//                            player.Cintura.SetActive(false);

//                        if (player.Cintura.transform.childCount > 0)
//                        {
//                            if (player.Cintura.transform.GetChild(0) != null)
//                            {
//                                player.Cintura.transform.GetChild(0).gameObject.SetActive(true);
//                            }
//                        }

//                        OclusionL(userId, player.Cintura.transform);

//                        overlayObject = player.Cintura.transform;
//                        Vector3 posJoint = manager.GetJointPosColorOverlay(userId, iJointIndex, foregroundCamera, backgroundRect);
//                        Quaternion rotJoint = manager.GetJointOrientation(userId, iJointIndex, false);

//                        if (posJoint != Vector3.zero)
//                        {
//                            if (overlayObject)
//                            {
//                                overlayObject.position = new Vector3(posJoint.x, posJoint.y, posJoint.z);
//                                overlayObject.rotation = Quaternion.Slerp(overlayObject.rotation, Quaternion.Euler(rotJoint.x, rotJoint.eulerAngles.y, rotJoint.z), smoothFactorRotation * Time.deltaTime);
//                            }
//                        }
//                    }
//                    else
//                    {
//                        player.Cintura.SetActive(false);
//                    }
//                }

//                float[] Lejania = { Vector3.Distance(players[0].ManoIzquierda.transform.position, FocusDistance.position), Vector3.Distance(players[1].ManoIzquierda.transform.position, FocusDistance.position),
//                    Vector3.Distance(players[2].ManoIzquierda.transform.position, FocusDistance.position),Vector3.Distance(players[3].ManoIzquierda.transform.position, FocusDistance.position) };

//                if (players[Array.IndexOf(Lejania, Lejania.Min())].ManoIzquierda.gameObject.activeSelf == true)
//                {

//                    ManoControl.transform.SetParent(players[Array.IndexOf(Lejania, Lejania.Min())].ManoIzquierda.transform);

//                    if (ManoControl.transform.parent.childCount > 1)
//                    {
//                        ManoControl.transform.parent.GetChild(0).gameObject.SetActive(false);
//                    }
//                }
//                ManoControl.SetActive(true);
//                ManoControl.transform.localPosition = Vector3.zero;
//                tracked = false;
//            }
//            else
//            {
//                foreach (Player player in players)
//                {
//                    player.ManoDerecha.SetActive(false);
//                    player.ManoIzquierda.SetActive(false);
//                    player.Cabeza.SetActive(false);
//                    ManoControl.transform.SetParent(Camera.main.transform);
//                }

//                if (HandCollision._estado == 0 && contador.activeSelf == false)
//                {
//                    panelPreDet.SetActive(true);
//                    if (Halloween)
//                    {
//                        HalloweenGirafa.localScale = Vector3.zero;
//                    }
//                }

//                if (HandCollision._estado == 0)
//                {
//                    if (panelPreDet.activeSelf)
//                    {
//                        fotoBoton.gameObject.SetActive(false);
//                        if (Halloween)
//                        {
//                            HalloweenGirafa.localScale = Vector3.zero;
//                        }
//                    }
//                    else
//                    {
//                        fotoBoton.gameObject.SetActive(true);
//                        if (Halloween)
//                        {
//                            HalloweenGirafa.localScale = new Vector3(0.1140961f, 0.1140961f, 0.1140961f);
//                        }
//                    }
//                }

//                fotoBoton.GetChild(0).GetComponent<Image>().fillAmount = 0;
//                fotoBoton.GetComponent<Button>().interactable = true;
//                fotoBoton.gameObject.SetActive(false);
//                _time += Time.deltaTime;
//                if (_time > 5)
//                {
//                    _time = 0;
//                    panelPreDet.transform.GetChild(indexImage).gameObject.SetActive(false);
//                    indexImage = (indexImage + 1) % panelPreDet.transform.childCount;
//                    panelPreDet.transform.GetChild(indexImage).gameObject.SetActive(true);
//                }
//            }
//        }
//        /*if (dictionary.Count > 0) {
//            var play1 = dictionary.OrderBy(c => c.Value).First();
//            ManoControl.transform.SetParent(play1.Key.ManoIzquierda.transform);
//            ManoControl.transform.localPosition = Vector3.zero;

//            dictionary.Clear();
//        }*/

//    }

//    void OclusionL(long userId, Transform overlayObject)
//    {
//        if (manager.GetLeftHandState(userId).ToString() != "NotTracked" && manager.GetLeftHandState(userId).ToString() == "Closed")
//        {
//            foreach (Transform child in overlayObject)
//            {
//                if (child.name == "Oclusion")
//                {
//                    //overlayObject.gameObject.SetActive(true);
//                    child.gameObject.SetActive(true);
//                }
//                if (child.name == "Particles")
//                {
//                    ParticleSystem ps = child.GetComponent<ParticleSystem>();
//                    var em = ps.emission;
//                    em.enabled = true;
//                }
//            }
//        }
//        else
//        {
//            foreach (Transform child in overlayObject)
//            {
//                if (child.name == "Oclusion")
//                {
//                    child.gameObject.SetActive(false);
//                }
//                if (child.name == "Particles")
//                {
//                    ParticleSystem ps = child.GetComponent<ParticleSystem>();
//                    var em = ps.emission;
//                    em.enabled = false;
//                }
//            }
//        }
//    }

//    void OclusionR(long userId, Transform overlayObject)
//    {
//        if (manager.GetRightHandState(userId).ToString() != "NotTracked" && manager.GetRightHandState(userId).ToString() == "Closed")
//        {
//            foreach (Transform child in overlayObject)
//            {
//                if (child.name == "Oclusion")
//                {
//                    child.gameObject.SetActive(true);
//                }
//                if (child.name == "Particles")
//                {
//                    ParticleSystem ps = child.GetComponent<ParticleSystem>();
//                    var em = ps.emission;
//                    em.enabled = true;
//                }
//            }
//        }
//        else
//        {
//            foreach (Transform child in overlayObject)
//            {
//                if (child.name == "Oclusion")
//                {
//                    child.gameObject.SetActive(false);
//                }
//                if (child.name == "Particles")
//                {
//                    ParticleSystem ps = child.GetComponent<ParticleSystem>();
//                    var em = ps.emission;
//                    em.enabled = false;
//                }
//            }
//        }
//    }

//    /*public string EstadoManos(long id, string ) {
//        iJointIndex = (int)KinectInterop.JointType.HandLeft;
//        if (manager.IsJointTracked(id, iJointIndex)) {
//            return manager.GetLeftHandState(id).ToString();
//        }}
//    }*/
//}