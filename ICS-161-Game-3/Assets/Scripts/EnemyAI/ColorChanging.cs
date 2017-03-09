using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorChanging : MonoBehaviour {

	public float SPEED;
	private Vector3 direction;
	public int count;
	public AudioClip a;
	void Start()
	{
		count = 0;
		direction = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 0));
	}

	void Update()
	{
		transform.position += direction * SPEED * Time.deltaTime;
    }
	private void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
	private void OnCollisionEnter(Collision collision){
		GameObject x = collision.gameObject;
		//Debug.Log (x.name);
		int[] dir = new int[2];
		dir [0] = -1;
		dir [1] = 1;

        //if (x.CompareTag("Wall") ||x.CompareTag("Alien home") || x.CompareTag("Enemy"))
        //{
        //    direction = new Vector3(0.0f, 0.0f, -1.0f);
        //    //rb.AddForce(direction*3);
        //}
        if (x.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (x.CompareTag("Bullet"))
        {
            if (count == 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                GameDecider.score += 1;
                count++;
                return;
            }
            if (count == 1)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                GameDecider.score += 1;
                count++;
                return;
            }
            GameDecider.score += 1;
            DestroyObject(gameObject);
            AudioSource.PlayClipAtPoint(a, transform.position);
        }
    }


}   
