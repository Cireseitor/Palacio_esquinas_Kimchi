using UnityEngine;

public class DisableKinectForTesting : MonoBehaviour
{
    void Start()
    {
        // Desactivar KinectManager si existe
        KinectManager kinectManager = FindObjectOfType<KinectManager>();
        if (kinectManager != null)
        {
            kinectManager.gameObject.SetActive(false);
            Debug.Log("KinectManager desactivado para testing");
        }
        
        // Desactivar FacetrackingManager si existe
        FacetrackingManager faceManager = FindObjectOfType<FacetrackingManager>();
        if (faceManager != null)
        {
            faceManager.gameObject.SetActive(false);
            Debug.Log("FacetrackingManager desactivado para testing");
        }
        
        // Desactivar otros componentes de Kinect
        GameObject[] kinectObjects = GameObject.FindGameObjectsWithTag("Kinect");
        foreach (GameObject obj in kinectObjects)
        {
            obj.SetActive(false);
        }
        
        Debug.Log("Todos los componentes de Kinect han sido desactivados para testing");
    }
}
