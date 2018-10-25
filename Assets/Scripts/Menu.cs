using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Button play;
	// Use this for initialization
	void Start () {
        AudioManager.instance.Play("MainTheme");
        play.Select();
    }
	
	// Update is called once per frame
	void Update () {


    }

}
