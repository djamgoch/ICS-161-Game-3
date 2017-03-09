using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDecider : MonoBehaviour {
	public static int score = 0;
    public static int health = 3;
    public Text countText;
    public Text timeText;
    public static float currentTime;
    //public GameObject[] Enemies;
    void Start(){
		currentTime = 0;
        setCountText();

    }

    void Update () {
        setCountText();
        currentTime += 1*Time.deltaTime;
        //Debug.Log(GameDecider.health);
        GameObject[] Enemies;
        GameObject[] Bullets;
        GameObject Player;
        //Debug.Log("health: " + health);
        //Debug.Log("score: " + score);
        Player = GameObject.FindGameObjectWithTag("Player");

        if (health <= 0)
        {
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            //foreach (GameObject t in Bullets)
            //{
            //    Destroy(t);
            //}
            Destroy(Player);

            SceneManager.LoadScene("Loser...");
        }
        if (currentTime >= 20 /*1000*/)
        {
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Bullets = GameObject.FindGameObjectsWithTag("Bullet");
            //Player = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            foreach (GameObject t in Bullets)
            {
                Destroy(t);
            }
            SceneManager.LoadScene("GameSceneLevel2");
        }

    }

    void setCountText()
    {
        timeText.text = "Time :" + (60 - currentTime).ToString();
        countText.text = "Score :" + score.ToString();
    }

}


