using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject timerText;
    private float timer;
    private float timer2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            timerText.SetActive(true);
            timer = 3.5f;
            timer2 = 8;
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
        }

        if (timer2 <= 0)
        {
            timerText.SetActive(false);
        }
	}
}
