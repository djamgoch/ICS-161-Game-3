using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//please remember to put all Scenes into the Build Settings
public class ButtonManager : MonoBehaviour {

    public void Start()
    {

    }
    public void Pausing()
    {
        GameObject[] MusicObjects;

    //pauses music when paused
        MusicObjects = GameObject.FindGameObjectsWithTag("Music");

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;

            foreach(GameObject t in MusicObjects)
            {
                t.SetActive(true);
            }
            return;
        }
        Time.timeScale = 0;

        //foreach (GameObject t in MusicObjects)
        //{
        //    t.SetActive(false);
        //}
    } 
    public void NewGameButton(string scene){
        Time.timeScale = 1;
        GameDecider.score = 0;
        GameDecider.health = 3;
        GameObject[] MusicObjects;
        GameObject[] Enemies;
        GameObject[] Player;
        MusicObjects = GameObject.FindGameObjectsWithTag("Music");

		Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		Player = GameObject.FindGameObjectsWithTag ("Player");
        foreach (GameObject t in MusicObjects)
        {
        Destroy(t);
        }
            foreach (GameObject t in Enemies)
        {
        Destroy(t);
        }
		foreach (GameObject t in Player)
		{
			Destroy(t);
		}

        SceneManager.LoadScene (scene);
	}


}
