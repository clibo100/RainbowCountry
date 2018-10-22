using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject titleText;
    public GameObject camera1;

    private float nextActionTime = 0.0f;
    private float period = 1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            Color c = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
            titleText.GetComponent<Text>().color = c;
            Color d = new Color(1.0f - c.r, 1.0f - c.g, 1.0f - c.b);
            camera1.GetComponent<Camera>().backgroundColor = d;
        }
    }
}
