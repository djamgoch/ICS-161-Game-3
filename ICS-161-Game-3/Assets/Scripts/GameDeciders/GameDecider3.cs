using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDecider3 : MonoBehaviour {
	public Text countText;
	public Text timeText;
    // Use this for initialization
    public GameObject[] Enemies;
    public GameObject Player;
    void Start () {
		setCountText ();
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
        foreach (GameObject t in Enemies)
        {
            Destroy(t);
        }

    }
	// indicators for w readability  clean sphere
    // Update is called once per frame
    void Update () {
		setCountText ();
		GameDecider.currentTime +=  1*Time.deltaTime;
        //Debug.Log (GameDecider.currentTime);
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");

        if (GameDecider.health <= 0)
        {

            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            Destroy(Player);
            SceneManager.LoadScene("Loser...");
        }
        if (GameDecider.currentTime >= 60)
        {
            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            Destroy(Player);
            SceneManager.LoadScene("Winner!");
        }
	}
	void setCountText(){
		countText.text = "Score :" + (GameDecider.score).ToString ();
        timeText.text = "Time: " + (60 - GameDecider.currentTime).ToString();
    }
}
