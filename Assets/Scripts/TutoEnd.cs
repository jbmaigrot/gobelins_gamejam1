using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoEnd : MonoBehaviour {

    public CameraScroll mainCamera;
    public GameObject player1;
    public GameObject player2;
    public GameObject death;
    public Collider2D invisibleWall;
    public GameObject ui;

    private Collider2D trigger;

	// Use this for initialization
	void Start () {
        trigger = GetComponent<Collider2D>();
	}

    // Update is called once per frame
    
	void Update () {
        if(player2.activeSelf)
        {
            if (trigger.bounds.Contains(player1.transform.position) && trigger.bounds.Contains(player2.transform.position))
            {
                mainCamera.moveSpeed = 3;
                death.SetActive(true);
                ui.SetActive(true);

            }
        }
        else
        {
            if (trigger.bounds.Contains(player1.transform.position))
            {
                mainCamera.moveSpeed = 3;
                death.SetActive(true);
                ui.SetActive(true);

            }
        }

	}
}
