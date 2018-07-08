using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] Transform target;

    private Vector3 offset;
    private float smoothing = 5f;
	
	void Start () {

        offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 targetPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
	}
}
