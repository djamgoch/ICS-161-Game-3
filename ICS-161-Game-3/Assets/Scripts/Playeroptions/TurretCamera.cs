using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCamera : MonoBehaviour {
    public GameObject Turret;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - Turret.transform.position;
        transform.rotation = Turret.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Turret.transform.position + offset;
        transform.rotation = Turret.transform.rotation;
    }
}
