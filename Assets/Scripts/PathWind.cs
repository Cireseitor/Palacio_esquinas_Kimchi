using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
public class PathWind : MonoBehaviour {
    private void Awake() {
        string path = Application.streamingAssetsPath + "/Config.xml";
        print(path);
       // TextAsset 
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Application.streamingAssetsPath + "/Config.xml");
        XmlNode node = xmlDoc.SelectNodes("/Config")[0];
    
        gameObject.GetComponent<UnityEngine.UI.Text>().text = node["consummer_key"].InnerText;
    } 
}
