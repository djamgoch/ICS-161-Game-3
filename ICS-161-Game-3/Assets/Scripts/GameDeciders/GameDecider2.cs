using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDecider2 : MonoBehaviour {
	public Text countText;
	public Text timeText;
    // Use this for initialization
    public GameObject[] Enemies;
    public GameObject Player;
    void Start () {
		setCountText ();
        //Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //foreach (GameObject t in Enemies)
        //{
        //    Destroy(t);
        //}

    }
    // Update is called once per frame
    void Update () {
		setCountText ();
		GameDecider.currentTime +=  1*Time.deltaTime;
        //Debug.Log (GameDecider.currentTime);
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //33 66 100 should be good imo for times
        if (GameDecider.health <= 0)
        {
            Player = GameObject.FindGameObjectWithTag("Player");

            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            Destroy(Player);
            SceneManager.LoadScene("Loser...");
        }
        if (GameDecider.currentTime >= 40)
        {
            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            SceneManager.LoadScene("GameSceneLevel3");
        }
	}

	void setCountText(){
		countText.text = "Score :" + (GameDecider.score).ToString ();
        timeText.text = "Time: " + (60-GameDecider.currentTime).ToString();

    }
}