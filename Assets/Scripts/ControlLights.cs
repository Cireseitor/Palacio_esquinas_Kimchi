using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlLights : MonoBehaviour {
    private Color32 color;
    private float RandomNumber;
	// Use this for initialization
	void Update () {
        Color temp = GetComponent<Image>().color;
       
        if (temp.a == RandomNumber) {
            RandomNumber = Random.Range((float)0, (float)0.6f);
            
        }
        temp.a = Mathf.MoveTowards(temp.a, RandomNumber, Time.deltaTime * 0.2f);
        GetComponent<Image>().color = temp;
    }
}
