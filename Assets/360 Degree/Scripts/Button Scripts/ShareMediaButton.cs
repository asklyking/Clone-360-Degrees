using UnityEngine;
using System.Collections;
using UnionAssets;

public class ShareMediaButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        UM_ShareUtility.ShareMedia("360 Degrees","This is my text to share");
        StartCoroutine(PostTwitterScreenshot());
    }

    private IEnumerator PostTwitterScreenshot()
    {

        yield return new WaitForEndOfFrame();
        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        UM_ShareUtility.TwitterShare("My Highscore", tex);

        Destroy(tex);

    }
}
