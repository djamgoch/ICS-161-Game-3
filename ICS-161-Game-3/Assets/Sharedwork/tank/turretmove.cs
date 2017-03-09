using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretmove : MonoBehaviour {
    public wheelmove tank;
    public Quaternion rotate;
    public float x;
    public float y;
    public float z;
    public int speed;
	void Start () {
        x = tank.x;
        y = tank.y;
        z = tank.z;
        speed = 5;
        rotate = Quaternion.Euler(x, y, z);
	}
	
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.W))
        {
            x -= 2;
        }
        if (Input.GetKey(KeyCode.S))
        {
            x += 2;
        }
        if (x > 0) x = 0;
        if (x < -80) x = -80;
        if (Input.GetKey(KeyCode.A))
        {
            y -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            y += speed;
        }
        if (y > tank.y + 90) y = tank.y + 90;
        if (y < tank.y - 90) y = tank.y - 90;
        rotate = Quaternion.Euler(x, y, z);
        transform.rotation = rotate;
    }
}
