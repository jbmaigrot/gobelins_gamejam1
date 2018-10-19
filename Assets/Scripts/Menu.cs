using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Button play;
    public Button quit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Command to restart the level
        if (Input.GetAxis("Vertical")<0)
        {
           quit.Select();
        }
        else if(Input.GetAxis("Vertical") > 0){
            play.Select();
        }

    }

}
