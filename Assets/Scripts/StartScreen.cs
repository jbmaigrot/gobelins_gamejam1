using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartScreen : MonoBehaviour {
    private float timevideo = 16;
    public VideoPlayer v;
	// Use this for initialization
	void Start () {
        v.Play();
	}
	
	// Update is called once per frame
	void Update () {
        timevideo -= Time.deltaTime;
        if(timevideo <=0)
        GameManager.Gm.SetLevel("Menu");
      
    }


}
