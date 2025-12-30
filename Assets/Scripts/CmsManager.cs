using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CmsManager : MonoBehaviour
{
    private string cmsURL = "https://palco-de-las-esquinas.imascono.tech/";
    public RawImage MarcoPantalla;

    public static CmsManager instance;
    public GameObject ObjectsMarcoseleccionado;
    public GameObject UIObjectsMarcoseleccionado, HandPlayers3D;

    private void Start()
    {
        instance = this;

        StartCoroutine(FotocallInfo());
    }

    IEnumerator FotocallInfo()
    {
        UnityWebRequest www = UnityWebRequest.Get(cmsURL + "items/contenido");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
            var data = JsonUtility.FromJson<RootObjectUser>(www.downloadHandler.text);
            var info = data.data;

            JointOverlayer.instance.experiencia = info.marco_seleccionado - 1;

            string selectedMarco = GetSelectedMarco(info);
            // Verificar si reposo está activo
            bool reposoActivo = JointOverlayer.instance.reposo.activeInHierarchy;

            if (!reposoActivo)
            {
                // Solo activar objetos del CMS si reposo NO está activo
                DesactivarTodosLosObjetos();
                ActivarMarcoSeleccionado(info.marco_seleccionado - 1);
            }
            else
            {
                // Si reposo está activo, desactivar todos los objetos del CMS
                DesactivarTodosLosObjetos();
            }

            if (!string.IsNullOrEmpty(selectedMarco))
            {
                yield return StartCoroutine(LoadImg(selectedMarco));
            }

            yield return new WaitForSeconds(60);
            StartCoroutine(FotocallInfo());
        }
    }

    private string GetSelectedMarco(User info)
    {
        switch (info.marco_seleccionado)
        {
            case 1: return info.marco_1;
            case 2: return info.marco_2;
            case 3: return info.marco_3;
            case 4: return info.marco_4;
            case 5: return info.marco_5;
            default: return null;
        }
    }

    private IEnumerator LoadImg(string imageID)
    {
        UnityWebRequest wwwLogo = UnityWebRequestTexture.GetTexture(cmsURL + "assets/" + imageID);
        yield return wwwLogo.SendWebRequest();

        if (wwwLogo.result == UnityWebRequest.Result.ConnectionError || wwwLogo.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(wwwLogo.error);
        }
        else
        {
            var texture = DownloadHandlerTexture.GetContent(wwwLogo);
            MarcoPantalla.texture = texture;
        }
    }

    public void OnReposoStateChanged()
    {
        // Verificar si reposo está activo
        bool reposoActivo = JointOverlayer.instance.reposo.activeInHierarchy;

        if (reposoActivo)
        {
            // Si reposo está activo, desactivar todos los objetos del CMS
            DesactivarTodosLosObjetos();
        }
        else
        {
            // Si reposo NO está activo, activar el marco seleccionado actual
            if (JointOverlayer.instance != null)
            {
                int marcoSeleccionado = JointOverlayer.instance.experiencia;
                DesactivarTodosLosObjetos();
                ActivarMarcoSeleccionado(marcoSeleccionado - 1);
            }
        }
    }

    private void DesactivarTodosLosObjetos()
    {
        foreach (Transform item in ObjectsMarcoseleccionado.transform)
        {
            item.gameObject.SetActive(false);
        }
        foreach (Transform item in UIObjectsMarcoseleccionado.transform)
        {
            item.gameObject.SetActive(false);
        }
        foreach (Transform item in HandPlayers3D.transform)
        {
            foreach (Transform item2 in item)
            {
                item2.gameObject.SetActive(false);
            }
        }
    }

    private void ActivarMarcoSeleccionado(int indiceMarco)
    {
        if (indiceMarco >= 0 && indiceMarco < ObjectsMarcoseleccionado.transform.childCount)
        {
            ObjectsMarcoseleccionado.transform.GetChild(indiceMarco).gameObject.SetActive(true);
        }
        if (indiceMarco >= 0 && indiceMarco < UIObjectsMarcoseleccionado.transform.childCount)
        {
            UIObjectsMarcoseleccionado.transform.GetChild(indiceMarco).gameObject.SetActive(true);
        }
        foreach (Transform item in HandPlayers3D.transform)
        {
            if (indiceMarco >= 0 && indiceMarco < item.transform.childCount)
            {
                item.transform.GetChild(indiceMarco).gameObject.SetActive(true);
            }
        }
    }
}

[System.Serializable]
public class RootObjectUser
{
    public User data;
}

[System.Serializable]
public class User
{
    public int marco_seleccionado;
    public string marco_1;
    public string marco_2;
    public string marco_3;
    public string marco_4;
    public string marco_5;
}
