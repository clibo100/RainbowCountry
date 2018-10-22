using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }

    private void OnMouseEnter()
    {
        gameObject.GetComponent<TextMesh>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<TextMesh>().color = Color.white;

    }
}
