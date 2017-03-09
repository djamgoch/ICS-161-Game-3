using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //spawn code originated from https://www.youtube.com/watch?v=WGn1zvLSndk
    //slight modifications to fit my game's purpose
    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public int maxNumberOfEnemies;
    public bool stop;
    //public GameObject x;
    public Transform[] positions;
    public Vector3 warning;
    //public int enemy;
    int randEnemy;
    int spawning;
    private int numOfEnemies;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(waitSpawner());
        numOfEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }
    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop && numOfEnemies <= maxNumberOfEnemies)
        {

            randEnemy = Random.Range(0, enemies.Length);
            //Debug.Log("randEnemy: " + randEnemy);
            Vector3 spawnPosition;
            if (enemies[randEnemy].name == "enemy plane")    // for spawning planes
            {
                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 6, spawnValues.z);
            }
            else if (enemies[randEnemy].name == "soldier (v2)")
            {
                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.9f, spawnValues.z);
            }
            else //if (enemies[randEnemy].name == "Enemy Tank (prototype v2)")
            {
                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.9f, spawnValues.z);
            }

            //if (randEnemy == 3)    // for spawning planes
            //{
            //    spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 6, spawnValues.z);
            //}
            //else
            //{
            //    spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.9f, spawnValues.z);
            //}

            //warning = new Vector3 (spawnPosition.x, 4, 22); // 20

            //var value = Instantiate (x,  warning, gameObject.transform.rotation);
            yield return new WaitForSeconds(0.15f);
            //Destroy (value, .20f);

            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            ++numOfEnemies;
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
