using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelmove : MonoBehaviour {
    public Quaternion rotate;
    public float x;
    public float y;
    public float z;
    public int angularSpeed;
    public int movementSpeed;
    void Start()
    {
        x = 0;
        y = 0;
        z = 0;
        //angularSpeed = 2;
        //movementSpeed = 3;
        rotate = Quaternion.Euler(x, y, z);
    }
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            y -= angularSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            y += angularSpeed;
        }
        rotate = Quaternion.Euler(x, y, z);
        transform.rotation = rotate;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward.normalized * movementSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody>().AddForce(-transform.forward.normalized * movementSpeed);
        }
    }
}
