using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatesManager : MonoBehaviour {

    public Text bestscore, gameplayed, totalscore, average, timespent, ruby;
	// Use this for initialization
	void Start () {
        bestscore.text = "Best Score:" + PlayerPrefs.GetInt("HighScore");
        gameplayed.text = "Game Played:" + PlayerPrefs.GetInt("gameplayed");
        totalscore.text = "Total Scores:" + PlayerPrefs.GetInt("totalscores");
        average.text = "Average:" + PlayerPrefs.GetFloat("avarage");
        timespent.text = "Time Spent:" + PlayerPrefs.GetString("timespent");
        ruby.text = "Rubies:" + PlayerPrefs.GetInt("Ruby");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BackToMenu()
    {
        Application.LoadLevel(0);
    }
}
