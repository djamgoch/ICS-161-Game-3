using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Splitting : MonoBehaviour {
	public float SPEED;
	private Vector3 direction;
	public AudioClip a;
    public GameObject movePrefab;
	void Start()
	{
		direction = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 0f));
	}

	void Update()
	{
		transform.position += direction * SPEED * Time.deltaTime;
		if(transform.position.y < 0)
            DestroyObject(gameObject);
    }

    private void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
    private void OnCollisionEnter(Collision x)
    {
        GameObject collide = x.gameObject;
        //if (collide.CompareTag("Wall") || collide.CompareTag("Alien home") || collide.CompareTag("Enemy"))
        //{
        //    direction = new Vector3(0.0f, 0.0f, -1.0f);
        //    //rb.AddForce(direction*3);
        //}
        if (collide.CompareTag("Player"))
        {
            Destroy(gameObject);
            //GameDecider.health -= 1;

        }
        if (collide.CompareTag("Bullet"))
        {

            //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //sphere.AddComponent<Rigidbody>();
            //sphere.transform.position = transform.position;
            //MoveRandomly sc = sphere.AddComponent<MoveRandomly>() as MoveRandomly;
            //sc.SPEED = 5;
            //sc.clip = a;
            //sc.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            //sc.
            //Instantiate(sc);
            //Instantiate(sc);
            Vector3 left_split = new Vector3(-2.0f, 0.0f, 2.0f);
            Vector3 right_split = new Vector3(2.0f, 0.0f, 2.0f);

            DestroyObject(gameObject);
            Instantiate(movePrefab, transform.position + left_split, Quaternion.identity);
            Instantiate(movePrefab, transform.position + right_split, Quaternion.identity);

            GameDecider.score += 1;


        }
    }

}   
