using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverCamera : MonoBehaviour {
    public GameObject playerTank;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - playerTank.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerTank.transform.position + offset;
	}
}
