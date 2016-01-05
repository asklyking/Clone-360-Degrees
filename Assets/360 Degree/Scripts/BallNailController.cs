using UnityEngine;
using System.Collections;

public class BallNailController : MonoBehaviour {

    GameObject ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
        transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 10f);
	}
}
