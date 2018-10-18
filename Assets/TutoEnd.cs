using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoEnd : MonoBehaviour {

    public CameraScroll mainCamera;
    public Transform player1;
    public Transform player2;
    public GameObject death;
    public Collider2D invisibleWall;

    private Collider2D trigger;

	// Use this for initialization
	void Start () {
        trigger = GetComponent<Collider2D>();
	}

    // Update is called once per frame
    
	void Update () {
        if (trigger.bounds.Contains(player1.position) && trigger.bounds.Contains(player2.position))
        {
            mainCamera.moveSpeed = 2;
            death.SetActive(true);
            invisibleWall.enabled = false;
        }
	}
}
