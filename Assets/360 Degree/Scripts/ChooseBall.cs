using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ChooseBall : MonoBehaviour {

    public static int choosen_ball;
    public Text ruby_number;

    public Button[] array_choice = new Button[5];
    public GameObject[] array_lock = new GameObject[5];

    public GameObject buy_btn, play_btn;
	// Use this for initialization
	void Start () {
        
        if (PlayerPrefs.HasKey("Ruby") == false)
        {
            PlayerPrefs.SetInt("Ruby", 5000);
        }
        PlayerPrefs.SetInt("unlock_ball0",1);
        play_btn.SetActive(true);
        buy_btn.SetActive(false);



        for (int i = 0; i < array_choice.Length; i++)
        {
            if (PlayerPrefs.HasKey("unlock_ball" + i) == true)
            {
                array_lock[i].SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        SetSource(choosen_ball);
        ruby_number.text = "You have " + PlayerPrefs.GetInt("Ruby") + " rubies";
        

        for(int i =0; i<array_choice.Length;i++)
        {
            if(PlayerPrefs.HasKey("unlock_ball"+i) == true)
            {
                array_lock[i].SetActive(false);
            }
        }
	}


    public void BackToMenu()
    {
        Application.LoadLevel(0);
    }

    public void chooseBall()
    {
        choosen_ball = 0;
        ActiveBtnPlay(0);
    }
    public void chooseBall1()
    {
        choosen_ball = 1;
        ActiveBtnPlay(1);
    }
    public void chooseBall2()
    {
        choosen_ball = 2;
        ActiveBtnPlay(2);
    }
    public void chooseBall3()
    {
        choosen_ball = 3;
        ActiveBtnPlay(3);
    }
    public void chooseBall4()
    {
        choosen_ball = 4;
        ActiveBtnPlay(4);
    }

    public void PlayGame()
    {
        Application.LoadLevel("MenuLevel");
    }

    public void BuyBall()
    {
        if (PlayerPrefs.GetInt("Ruby") >= 100)
        {

            PlayerPrefs.SetInt("Ruby", PlayerPrefs.GetInt("Ruby") - 100);
            PlayerPrefs.SetInt("unlock_ball" + choosen_ball, 1);
            ActiveBtnPlay(choosen_ball);
        }
    }

    void SetSource(int i)
    {
        for(int k=0;k<array_choice.Length;k++)
        {
            array_choice[k].GetComponent<Image>().sprite = null;
        }
        array_choice[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("choosen"); ;
    }

    void ActiveBtnPlay(int i)
    {
        if (PlayerPrefs.HasKey("unlock_ball" + i) == true)
        {
            play_btn.SetActive(true);
            buy_btn.SetActive(false);
        }
        else
        {
            play_btn.SetActive(false);
            buy_btn.SetActive(true);
        }
    }

}
