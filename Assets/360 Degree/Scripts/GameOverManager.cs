using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour {

    public Text show_score;
    public Text show_high_score;

    public GameObject dialog;
	// Use this for initialization
	void Start () {

        dialog.SetActive(false);
        if (PlayerPrefs.HasKey("HighScore") == false)
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        show_score.text = "" + GameManager.Score;
        if (PlayerPrefs.GetFloat("HighScore") < GameManager.Score)
        {

            dialog.SetActive(true);
            PlayerPrefs.SetInt("HighScore", GameManager.Score);
            show_high_score.text = "Best score: " + GameManager.Score;
            PlayerPrefs.Save();
        }
        else
        {
            show_score.text = ""+GameManager.Score;
            show_high_score.text = "Best score: " + PlayerPrefs.GetInt("HighScore");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadBonus()
    {
        Application.LoadLevel("Bonus");
    }

    public void NoLoadBonus()
    {
        dialog.SetActive(false);
    }
}
