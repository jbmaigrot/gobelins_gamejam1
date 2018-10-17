using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWhite : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();
	}
    
    private void HandleInput()
    {
        // Dash input
        if (Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log("1");
        }

        if (Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("2");
        }

        if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("3");
        }

        if (Input.GetKeyDown("joystick button 4"))
        {
            Debug.Log("4");
        }

        if (Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("5");
        }

        if (Input.GetKeyDown("joystick button 6"))
        {
            Debug.Log("6");
        }

        if (Input.GetKeyDown("joystick button 7"))
        {
            Debug.Log("7");
        }

        if (Input.GetKeyDown("joystick button 8"))
        {
            Debug.Log("8");
        }

        if (Input.GetKeyDown("joystick button 9"))
        {
            Debug.Log("9");
        }

        if (Input.GetKeyDown("joystick button 10"))
        {
            Debug.Log("10");
        }
    }
}
