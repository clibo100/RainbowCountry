using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject timerText;
    public GameObject timerBackground;
    private float timer;
    private float timer2;
    private bool hasSetColors = false;

    public GameObject camera1;
    public GameObject camera2;

	// Use this for initialization
	void Start () {
        timerText.SetActive(true);
        timer = 3.5f;
        timer2 = 8;
    }
	
	// Update is called once per frame
	void Update () {

        if (Mathf.Round(timer) > 0)
        {
            timer -= Time.deltaTime / 1.5f;
            timerText.GetComponent<Text>().text = Mathf.Round(timer).ToString();
        }

        if (timer2 > 0)
        {
            timer2 -= Time.deltaTime;
        }

        if (Mathf.Round(timer) <= 0 && timer2 > 0)
        {
            timerText.GetComponent<Text>().text = "GO!";
            if (!hasSetColors)
            {
                Color color1 = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                Color color2 = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

                while (Mathf.Abs(color1.r - color2.r) >= 0.5 && Mathf.Abs(color1.g - color2.g) >= 0.5 && Mathf.Abs(color1.b - color2.b) >= 0.5)
                {
                    color2 = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                }

                camera1.GetComponent<Camera>().backgroundColor = color1;
                camera2.GetComponent<Camera>().backgroundColor = color2;
                hasSetColors = true;
            }
        }

        if (timer2 <= 0)
        {
            timerText.SetActive(false);
            timerBackground.SetActive(false);
        }
	}
}
