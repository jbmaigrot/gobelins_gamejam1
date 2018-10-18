using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {
    [SerializeField]
    private Transform[] pathPoints;
    [SerializeField]
    public float moveSpeed;

    private int currentPoint;

    [SerializeField]
    private GameObject background;

    void Start () {
        transform.position = pathPoints[0].position;
        currentPoint = 0;
    }
	
	void Update () {
        // When the camera arrived to the currentPoint it aim the next point
        if (transform.position == pathPoints[currentPoint].position && currentPoint < (pathPoints.Length-1))
        {
            currentPoint = (currentPoint + 1);
        }
        // Camera moving to the next pathPoint
        transform.position = Vector3.MoveTowards(transform.position, pathPoints[currentPoint].position, moveSpeed * Time.deltaTime);
        background.transform.position = Vector3.MoveTowards(background.transform.position, pathPoints[currentPoint].position, moveSpeed/7 * Time.deltaTime);
    }
}
