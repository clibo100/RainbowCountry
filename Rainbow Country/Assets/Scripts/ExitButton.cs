using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Application.Quit();
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
