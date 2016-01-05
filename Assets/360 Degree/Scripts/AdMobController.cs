using UnityEngine;
using System.Collections;

public class AdMobController : MonoBehaviour {

    private int bannerId1 = 0;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        UM_AdManager.instance.Init();
        bannerId1 = UM_AdManager.instance.CreateAdBanner(TextAnchor.LowerCenter);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
