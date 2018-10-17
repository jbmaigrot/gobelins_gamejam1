using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunner : MonoBehaviour {
    [SerializeField]
    private GameObject Doug;
    [SerializeField]
    private GameObject Bong;
    [SerializeField]
    private float limit;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 DougPosScreen = Camera.main.WorldToScreenPoint(Doug.transform.position);
        Vector3 BongPosScreen = Camera.main.WorldToScreenPoint(Bong.transform.position);
        if (DougPosScreen.x == limit)
        {
           
        }

	}
}
