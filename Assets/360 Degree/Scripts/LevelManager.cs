using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    int num_level = 4;
    public static string current_level;
    public GameObject[] image_lock = new GameObject[4];

    public GameObject dialog,sucess_dialog;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("unlock_lv0",1);

        dialog.SetActive(false);
        sucess_dialog.SetActive(false);

        for (int i = 0; i < num_level; i++)
        {
            if (PlayerPrefs.HasKey("unlock_lv" + i) == true)
            {
                image_lock[i].SetActive(false);
            }
            else
            {
                image_lock[i].SetActive(true);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < num_level; i++)
        {
            if (PlayerPrefs.HasKey("unlock_lv" + i) == true)
            {
                image_lock[i].SetActive(false);
            }
            else
            {
                image_lock[i].SetActive(true);
            }
        }
	}

    public void LoadLevel1()
    {
        if (PlayerPrefs.HasKey("unlock_lv" + 0) == true)
        {
            Application.LoadLevel("Level1");
            current_level = "Level1";
        }
    }

    public void LoadLevel2()
    {
        if (PlayerPrefs.HasKey("unlock_lv" + 1) == true)
        {
            Application.LoadLevel("Level2");
            current_level = "Level2";
        }
        else
        {
            if (PlayerPrefs.GetInt("Ruby") > 250)
            {
                PlayerPrefs.SetInt("unlock_lv1", 1);
                sucess_dialog.SetActive(true);
            }
            else
            {
                dialog.SetActive(true);
            }
        }
    }

    public void LoadLevel3()
    {
        if (PlayerPrefs.HasKey("unlock_lv" + 2) == true)
        {
            Application.LoadLevel("Level3");
            current_level = "Level3";
        }
        else
        {
            if (PlayerPrefs.GetInt("Ruby") > 250)
            {
                PlayerPrefs.SetInt("unlock_lv2", 1);
                sucess_dialog.SetActive(true);
            }
            else
            {
                dialog.SetActive(true);
            }
        }
    }

    public void LoadLevel4()
    {
        if (PlayerPrefs.HasKey("unlock_lv" + 3) == true)
        {
            Application.LoadLevel("Level4");
            current_level = "Level4";
        }
        else
        {
            if (PlayerPrefs.GetInt("Ruby") > 250)
            {
                PlayerPrefs.SetInt("unlock_lv3", 1);
                sucess_dialog.SetActive(true);
            }
            else
            {
                dialog.SetActive(true);
            }
        }
    }
    public void BackToMenu()
    {
        Application.LoadLevel("Home");
    }

    public void Ok_btn()
    {
        dialog.SetActive(false);
        sucess_dialog.SetActive(false);
    }
}
