using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    public int player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player == 1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, 0, 1f);
                Debug.Log("ROTATION: " + transform.rotation.eulerAngles);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 0, -1f);
                Debug.Log("ROTATION: " + transform.rotation.eulerAngles);
            }
        }

        if (player == 2)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, 0, 1f);
                Debug.Log("ROTATION: " + transform.rotation.eulerAngles);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 0, -1f);
                Debug.Log("ROTATION: " + transform.rotation.eulerAngles);
            }
        }
    }
}
