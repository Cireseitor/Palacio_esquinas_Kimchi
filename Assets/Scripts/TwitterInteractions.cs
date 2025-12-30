using System.IO;
using UnityEngine;
using System.Xml;

public class TwitterInteractions : MonoBehaviour {
    public static string impresora;

    public string CONSUMER_KEY;
    public string CONSUMER_SECRET;
    public string CONSUMER_TOKEN;
    public string CONSUMER_TOKEN_SECRET;

    public delegate void MyDelegate(bool success);
    public MyDelegate onPostImage, onPostTuit;

    Twitter.AccessTokenResponse m_AccessTokenResponse;



    public void testCLick() {
        PostImage();
    }

    void Awake() {
     /*   XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Application.streamingAssetsPath + "/Config.xml");
        XmlNode node = xmlDoc.SelectNodes("/Config")[0];
        if (node["consummer_key"].InnerText != "" && node["consummer_secret"].InnerText != "" &&
            node["consummer_token"].InnerText != "" && node["consummer_token_secret"].InnerText != "") {
            CONSUMER_KEY = node["consummer_key"].InnerText;
            CONSUMER_SECRET = node["consummer_secret"].InnerText;
            CONSUMER_TOKEN = node["consummer_token"].InnerText;
            CONSUMER_TOKEN_SECRET = node["consummer_token_secret"].InnerText;
        }
        if (node["impresora"].InnerText != "") {
            print("we");
            impresora = node["impresora"].InnerText;
            print(impresora);
        }*/
        LoadTwitterUserInfo();
       // gameObject.SetActive(false);
    }

    void LoadTwitterUserInfo() {
        m_AccessTokenResponse = new Twitter.AccessTokenResponse();
        
        m_AccessTokenResponse.Token = CONSUMER_TOKEN;
        m_AccessTokenResponse.TokenSecret = CONSUMER_TOKEN_SECRET;

        if (!string.IsNullOrEmpty(m_AccessTokenResponse.Token) &&
            !string.IsNullOrEmpty(m_AccessTokenResponse.TokenSecret)) {
            Debug.Log("LoadTwitterUserInfo - succeeded");
        }
    }

    public void PostImage() {
        print(Application.persistentDataPath);
        var image = File.ReadAllBytes(Application.persistentDataPath+ "/lost.jpg");
        StartCoroutine(Twitter.API.PostImage(image, CONSUMER_KEY, CONSUMER_SECRET, m_AccessTokenResponse,
                      new Twitter.PostImageCallback(OnPostImage)));
    }

    void OnPostImage(bool success, Twitter.PostImageResponse response) {
        if (success) {
            var m_Tweet = "Kinect Photo Show";
            StartCoroutine(Twitter.API.PostTweet(m_Tweet, CONSUMER_KEY, CONSUMER_SECRET, m_AccessTokenResponse,
                         new Twitter.PostTweetCallback(OnPostTweet), response.media_id_string));
        }
        if (onPostImage != null)
            onPostImage(success);
        print("OnPostImage - " + (success ? "succedded." : "failed."));
    }

    void OnPostTweet(bool success) {
        if (onPostTuit!= null)
            onPostTuit(success);
        print("OnPostTweet - " + (success ? "succedded." : "failed."));
    }
}
