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
        if (Input.GetKeyDown("c"))
        {
            if (this.gameObject.layer == 9)
                this.gameObject.layer = 8;
            else
                this.gameObject.layer = 9;
        }
    }
}
