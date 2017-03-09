﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Monobehaviour/component used to define the AI for
 * tanks and soldiers.
 * A tanks and/or soldier continously follow the player tank.
 * When a tank/soldier gets within a certain radius (defined by
 * stopping distance in the NavMeshAgent component), it starts 
 * shooting at the player.
 * There is also an option to turn on spliting after the tank/soldier
 * dies.
 */
public class FollowAndShoot : MonoBehaviour
{
    public AudioClip clip;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;   // needs to be the gameobject that physically represents the gun barrel (NOT ITS PARENT OBJECT!)
    public GameObject movePrefab;
    public float FireCooldownTime;
    public float BulletLifeSeconds = 6.0f;
    public float BulletSpawnDistanceScale = 2.0f;
    public bool SplitOnDeath;       // if true, enemies splits into movePrefab upon death. if false, it dies normally.

    private NavMeshAgent agent;
    private GameObject player;
    private float fireCooldownTimer;
    private bool coolingDown;
    private Vector3 aimPoint;

    private void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        //Debug.Log("enemy tank instantiated");
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        if (player != null) agent.SetDestination(player.transform.position);
        aimPoint = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        fireCooldownTimer = 0.0f;
        coolingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");
        agent.SetDestination(player.transform.position);
        aimPoint.x = player.transform.position.x;
        aimPoint.z = player.transform.position.z;
        transform.LookAt(aimPoint /*player.transform*/);

        if (coolingDown)
        {
            if (fireCooldownTimer < FireCooldownTime)
            {
                fireCooldownTimer += 1.0f * Time.deltaTime;
            }
            else
            {
                fireCooldownTimer = 0.0f;
                coolingDown = false;
            }
        }
        //Debug.Log("cooldownTimer: " + fireCooldownTimer % (FireCooldownTime));
    }

    private void FixedUpdate()
    {
        Vector3 origin = bulletSpawn.transform.position + transform.forward.normalized * 2.0f;
        RaycastHit hit;
        bool pointingAtObject = Physics.Raycast(origin, transform.forward.normalized, out hit);
        if (pointingAtObject)
        {
            Transform target = hit.transform;
            //Debug.Log(target.tag);
            //Debug.Log("remaining distance: " + agent.remainingDistance);
            //Debug.Log("stopping distance: " + agent.stoppingDistance);
            if (agent.remainingDistance <= agent.stoppingDistance && agent.remainingDistance > 0.0f && !coolingDown && target.tag == "Player")
            {
                //Debug.Log("cooldownTimer: " + fireCooldownTimer % (FireCooldownTime));
                Fire();
            }

            //agent.
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject x = collision.gameObject;
        //Debug.Log (x.name);
        if (x.CompareTag("Player"))
        {
            //GameDecider.losing += 1;
            Destroy(gameObject);
        }
        if (x.CompareTag("Bullet"))
        {
            if (SplitOnDeath)
            {
                //Debug.Log("Enemy Tank destroyed");
                Vector3 left_split = new Vector3(-2.0f, 0.0f, 2.0f);
                Vector3 right_split = new Vector3(2.0f, 0.0f, 2.0f);

                AudioSource.PlayClipAtPoint(clip, transform.position);
                DestroyObject(gameObject);

                if (movePrefab != null)
                {
                    Instantiate(movePrefab, transform.position + left_split, Quaternion.identity);
                    Instantiate(movePrefab, transform.position + right_split, Quaternion.identity);
                }

                else
                {
                    Debug.Log("Did not assign an object prefab to movePrefab variable!");
                }
            }

            else
            {
                Debug.Log("Soldier destroyed");
                AudioSource.PlayClipAtPoint(clip, transform.position);
                Destroy(gameObject);
            }

            GameDecider.score += 1;
        }


    }

    void Fire()
    {
        //if (SplitOnDeath) Debug.Log(name + ": tank fired bullet");
        //else Debug.Log(name + ": soldier fired bullet");

        // Create the Bullet from the Bullet Prefab
        // Transform bulleting = bulletSpawn.position;

        // edit by David Jamgochian 2/28/17 
        //starts here

        // old code
        /*var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);*/

        Vector3 offset = /*bulletSpawn.up.normalized +*/ bulletSpawn.up.normalized * bulletSpawn.lossyScale.y
            * BulletSpawnDistanceScale;
        //Debug.Log("Scale: " + bulletSpawn.lossyScale);

        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position + offset,
            bulletSpawn.rotation);

        bullet.transform.localScale = new Vector3(bulletSpawn.lossyScale.y, bulletSpawn.lossyScale.y, bulletSpawn.lossyScale.y);
        // ends here

        Destroy(bullet, BulletLifeSeconds);
        coolingDown = true;

    }

}
