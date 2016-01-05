using UnityEngine;
using System.Collections;

public class LeaderboardButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        UM_GameServiceManager.instance.ShowLeaderBoardsUI();
        Debug.Log("ok");
    }
}
