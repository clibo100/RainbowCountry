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

    public GameObject arrow1;
    public GameObject arrow2;

    public GameObject frown1;
    public GameObject frown2;

    private bool oneHasGone = false;
    private bool twoHasGone = false;

    private float endTime;
    private bool hasStartedEndTime = false;


    float h1, s1, v1;
    float h2, s2, v2;


    // Use this for initialization
    void Start () {
        timerText.SetActive(true);
        timer = 3.5f;
        timer2 = 8;
    }
	
	// Update is called once per frame
	void Update () {
        if (oneHasGone && twoHasGone && !hasWon)
        {
            winText.GetComponent<Text>().text = "You all lose :(";
            winText.SetActive(true);
            endTime = Time.time + 1f;
            hasStartedEndTime = true;
        }

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

                Color color2 = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

                while (Mathf.Abs(color1.r - color2.r) <= 0.5 && Mathf.Abs(color1.g - color2.g) <= 0.5 && Mathf.Abs(color1.b - color2.b) <= 0.5)
                {
                    color2 = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                }

                Color.RGBToHSV(color1, out h1, out s1, out v1);
                Color.RGBToHSV(color1, out h2, out s2, out v2);

                Debug.Log("HUE : " + h1);

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

        if (hasSetColors && Input.GetKeyDown(KeyCode.E) && !hasWon && !oneHasGone)
        {
            if (Mathf.Abs(arrow1.transform.rotation.eulerAngles.z /360 - h1) < 0.1)
            {
                winText.GetComponent<Text>().text = "PLAYER 1 WINS";
                winText.SetActive(true);
                hasWon = true;
                endTime = Time.time + 3f;
                hasStartedEndTime = true;
                oneHasGone = true;
            }
            else
            {
                frown1.SetActive(true);
                oneHasGone = true;
            }
        }
        else if (hasSetColors && Input.GetKeyDown(KeyCode.Return) && !hasWon && !twoHasGone)
        {
            if (Mathf.Abs(arrow1.transform.rotation.eulerAngles.z / 360 - h1) < 0.1)
            {
                winText.GetComponent<Text>().text = "PLAYER 2 WINS";
                winText.SetActive(true);
                hasWon = true;
                endTime = Time.time + 3f;
                hasStartedEndTime = true;
                twoHasGone = true;
            }
            else
            {
                frown2.SetActive(true);
                twoHasGone = true;
            }
        }

        if (hasStartedEndTime && endTime <= Time.time)
        {
            SceneManager.LoadScene(0);
        }
	}
}
