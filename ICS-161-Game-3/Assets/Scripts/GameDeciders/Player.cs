using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

//roll a ball tutorial
public class Player : MonoBehaviour {
    //from unity bullet tutorial
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    //public Vector3 move;
    //used Kyle's invulnerability code;
    public UnityEvent onBulletHit;
    private Animator anim;
    private bool isVulnerable = true;
    /// time delay
    public float timeBetweenShots = 0.05f;  // Allow 3 shots per second
    //AudioSource audio;
    //public AudioClip impact;

    private float timestamp;
    GameObject t;
    /// </summary>
    // Use this for initialization
    private bool Vulnerable
    {
        get
        {
            return isVulnerable;
        }
        set
        {
            isVulnerable = value;
            anim.SetBool("isVulnerable", isVulnerable);
        }
    }
    private void Awake()
    {
        // edit by David Jamgochian 3/7/2017: I commented out the line right below.
        //DontDestroyOnLoad(transform.gameObject);
        //audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);

        t = GameObject.FindGameObjectWithTag("MainCamera");
        anim = GetComponent<Animator>();
        Vulnerable = true;
        onBulletHit.AddListener(() => {
            MakeInvulnerable();
        });
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject x = collision.gameObject;

        // edit by David Jamgochian 3/7/2017: I added "|| x.CompareTag("Bullet")" to the if-condition
        if (x.gameObject.CompareTag("Enemy") || x.CompareTag("Badbullet"))
        {
            //audio.PlayOneShot(impact, 0.7F);
            //GameObject []t = GameObject.FindGameObjectsWithTag("MainCamera");
            //foreach(GameObject z in t)
            //{

            //}
            Destroy(x.gameObject);
            if (Vulnerable)
            {
                GameDecider.health -= 1;
				//if (GameDecider.health <= -1800) {
				//	Destroy (gameObject);
				//	SceneManager.LoadScene ("Loser...");

				//}
                //Debug.Log("hi");
                anim.Play("Invulnerable");
                MakeInvulnerable();
                t.BroadcastMessage("DoShake");
            }
        }

    }

    private void MakeVulnerable()
    {
        Vulnerable = true;
    }

    private void MakeInvulnerable()
    {
        Vulnerable = false;
        Invoke("MakeVulnerable", 1.5f);
    }
    //end of Invulnerable code
    void Start () {
    }

    // Update is called once per frame
    void FixedUpdate () {
        //recently added
        Vector3 clamp = transform.position;
        //edit by David Jamgochian 3/1/2017
        //starts here
        // old code
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        // new code
        //float moveHorizontal = 0.0f;
        //float moveVertical = 0.0f;
        //Vector3 direction = new Vector3();
        //if (Input.GetKey(KeyCode.UpArrow)) moveVertical = speed;
        //if (Input.GetKey(KeyCode.DownArrow)) moveVertical = -speed;
        //if (Input.GetKey(KeyCode.LeftArrow)) moveHorizontal = -speed;
        //if (Input.GetKey(KeyCode.RightArrow)) moveHorizontal = speed;
        clamp.x = Mathf.Clamp(clamp.x , -130f, 90f);
        clamp.z = Mathf.Clamp(clamp.z , -50f, 50f);

        transform.position = clamp;
        if ((Input.GetKeyDown(KeyCode.Space))){// GameDecider.currentTime >= timestamp &&) {
            //timestamp = GameDecider.currentTime + timeBetweenShots;
            Fire();
        }
        //1move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //transform.position += move * speed * Time.deltaTime;
    }
    //recently added
    void Fire()
    {


        // Create the Bullet from the Bullet Prefab
        //Transform bulleting = bulletSpawn.position;

        // edit by David Jamgochian 2/28/17 
        //starts here

        // old code
        /*var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);*/

        // edit by David Jamgochian 3/7/2017: I increased the scale of how far the bullet spawns to prevent the players
        // from doing damage to self. Just paste the line below over the old one.
        Vector3 offset = /*bulletSpawn.up.normalized +*/ bulletSpawn.up.normalized * bulletSpawn.lossyScale.y * 2.0f;
        //Debug.Log("Scale: " + bulletSpawn.lossyScale);

        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position + offset,
            bulletSpawn.rotation);
        // ends here

        Destroy(bullet, 3.0f);

    }


    

}
