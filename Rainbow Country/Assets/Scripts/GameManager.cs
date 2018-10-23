using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject timerText;
    public GameObject timerBackground;
    private float timer;
    private float timer2;

    private bool hasSetColors = false;
    private bool hasWon = false;

    public GameObject camera1;
    public GameObject camera2;

    public GameObject player1;
    public GameObject player2;

    public GameObject winText;

    private float endTime;
    private bool hasStartedEndTime = false;


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
            player1.SetActive(true);
            player2.SetActive(true);
            if (!hasSetColors)
            {
                Color color1 = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                Debug.Log("R: " + color1.r + " G: " + color1.g + " B: " + color1.b);
                float h, s, v;
                Color.RGBToHSV(color1, out h, out s, out v);
                Debug.Log("HUE : " + h);

                Color color2 = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

                while (Mathf.Abs(color1.r - color2.r) <= 0.5 && Mathf.Abs(color1.g - color2.g) <= 0.5 && Mathf.Abs(color1.b - color2.b) <= 0.5)
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

        if (hasSetColors && Input.GetKeyDown(KeyCode.E) && !hasWon)
        {
            winText.GetComponent<Text>().text = "PLAYER 1 WINS";
            winText.SetActive(true);
            hasWon = true;

            endTime = Time.time + 3f;
            hasStartedEndTime = true;
        }
        else if (hasSetColors && Input.GetKeyDown(KeyCode.Return) && !hasWon)
        {
            winText.GetComponent<Text>().text = "PLAYER 2 WINS";
            winText.SetActive(true);
            hasWon = true;

            endTime = Time.time + 3f;
            hasStartedEndTime = true;
        }

        if (hasStartedEndTime && endTime <= Time.time)
        {
            SceneManager.LoadScene(0);
        }
	}
}
