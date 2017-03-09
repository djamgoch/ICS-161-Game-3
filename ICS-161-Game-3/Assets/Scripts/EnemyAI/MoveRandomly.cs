using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveRandomly : MonoBehaviour {
	public Text countText;
	public float SPEED;
	private Vector3 direction;
    public AudioClip clip;
    public AudioClip clip2;
	public static bool right_color = true;
	void Start()
	{

		direction = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 0));
	}

	void Update()
	{
			transform.position += direction * SPEED * Time.deltaTime;
        //SceneManager.LoadScene("Loser...");
    }


	private void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
    private void OnCollisionEnter(Collision collision) {
        GameObject x = collision.gameObject;
        //Debug.Log (x.name);
        int[] dir = new int[2];
        dir[0] = -1;
        dir[1] = 1;
        if (x.CompareTag("Player"))
        {
            //GameDecider.losing += 1;
            AudioClip t = clip2;
            AudioSource.PlayClipAtPoint(t, transform.position);
            Destroy(gameObject);
        }
        else if (x.CompareTag("Bullet"))
        {
            AudioClip t = clip;
            AudioSource.PlayClipAtPoint(t, transform.position);
            GameDecider.score += 1;
            Destroy(gameObject);
        }
  //      if (x.CompareTag ("Wall")  || x.CompareTag("Alien home"))
  //      {
		//	direction = new Vector3 (0.0f, 0.0f, -1.0f);
		//	//rb.AddForce(direction*3);
		//}
      
	}

}   
