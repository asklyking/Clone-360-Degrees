﻿using UnityEngine;
using System.Collections;

public class GuideButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void OnMouseDown()
    {
        Application.LoadLevel("Guide");
    }
}
