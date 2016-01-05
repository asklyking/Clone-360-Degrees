using UnityEngine;
using System.Collections;

public class BuyRubyManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Buy250()
    {
        PlayerPrefs.SetInt("Ruby",PlayerPrefs.GetInt("Ruby")+250);
        Application.LoadLevel("Home");
    }

    public void Buy550()
    {
        PlayerPrefs.SetInt("Ruby", PlayerPrefs.GetInt("Ruby") + 250);
        Application.LoadLevel("Home");
    }

    public void Buy900()
    {
        PlayerPrefs.SetInt("Ruby", PlayerPrefs.GetInt("Ruby") + 250);
        Application.LoadLevel("Home");
    }

}
