using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject win;
    public GameObject lose;
    public GameObject one;
    public GameObject two;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EndGame(bool victoire, string player)
    {
        if (!victoire)
        {
            lose.SetActive(true);  
        }
        else
        {
            win.SetActive(true);
        }

        if (player == "One")
        {
            one.SetActive(true);
        }
        if (player == "Two")
        {
            two.SetActive(true);
        }

    }

}
