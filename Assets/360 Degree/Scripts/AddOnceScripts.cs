using UnityEngine;
using System.Collections;

public class AddOnceScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroyAddOne", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DestroyAddOne()
    {
        Destroy(gameObject);
    }
}
