using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    float force = 2f;
    public GameObject explosion;

    public GameObject add_one;
    public GameObject Diamond;
    public GameObject ball_nail;
    public GameObject Shield;
    public GameObject Shield_canvas;
    public GameObject Ruby;
    public bool have_shield = false;

    

    public GameObject Ruby_Canvas;
	// Use this for initialization
	void Start () {


        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        PlayerPrefs.SetInt("gameplayed", PlayerPrefs.GetInt("gameplayed")+1);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 1f) * 500 * (1 / Time.timeScale));
        ball_nail.SetActive(true);
        Shield_canvas.SetActive(false);


        Debug.Log(ChooseBall.choosen_ball);
        if(ChooseBall.choosen_ball ==0)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Ball");
        }
        if (ChooseBall.choosen_ball == 1)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Ball1");
        }
        if (ChooseBall.choosen_ball == 2)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Ball2");
        }
        if (ChooseBall.choosen_ball == 3)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Ball3");
        }
        if (ChooseBall.choosen_ball == 4)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Ball4");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (have_shield == true)
       {
           ball_nail.SetActive(true);
           Shield_canvas.SetActive(true);
           Shield.SetActive(false);
           
       }
        else
       {
           ball_nail.SetActive(false);
           Shield_canvas.SetActive(false);
       }


        if(GameManager.pause_game == true)
        {
            this.GetComponent<TrailRenderer>().enabled = false;
        }
        else
        {
            this.GetComponent<TrailRenderer>().enabled = true;
        }
        Shield.SetActive(GameManager.active_shield);
        Ruby.SetActive(GameManager.active_ruby);

        //Ruby.transform.localEulerAngles = new Vector3(0, 0, 79.05804f);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Diamond")
        {
            GameManager.Score++;
            //other.gameObject.SetActive(false);
            //GameManager.destroyed_diamond = true;
            float[] pos = new float[] { -1,1.5f,0,-1.5f,2};
            Diamond.transform.position = new Vector3(pos[Random.Range(0, pos.Length)], pos[Random.Range(0, pos.Length)], Diamond.transform.position.z);
        }

        if(other.tag == "Ruby")
        {
            Instantiate(add_one,transform.position,transform.rotation);
            Ruby.SetActive(true);
            GameManager.active_ruby = false;
            GameManager.Ruby_Num++;
            float[] pos = new float[] { -2.5f,2.5f,3f,-3f };
            Ruby.transform.position = new Vector3(pos[Random.Range(0, pos.Length)], pos[Random.Range(0, pos.Length)], Ruby.transform.position.z);
        }


        if(other.tag == "Nail")
        {
            Instantiate(explosion,transform.position,transform.rotation);
            


            if(have_shield == true)
            {
                GameManager.Ruby_Num = 0;
                Invoke("ResetShield", 0.1f);

                SlowTimeScaleGame();
                Invoke("ResetTimeScaleGame", 3f);
            }
            else
            {
                Destroy(GetComponent<Rigidbody2D>());
                //GameManager.Ruby_Total += GameManager.Ruby_Num;
                Invoke("LoadScenes", 0.5f);
            }
        }


        if(other.tag == "Shield")
        {
            have_shield = true;
            GameManager.active_shield = false;
            other.gameObject.SetActive(false);
        }

        if(other.tag == "Ring")
        {
            GameManager.touch_ring = true;
            float[] pos = new float[] { -2.5f, 2.5f, 3f, -3f };
            Ruby.transform.position = new Vector3(pos[Random.Range(0, pos.Length)], pos[Random.Range(0, pos.Length)], Ruby.transform.position.z);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameManager.touch_ring = false;
    }
    public void LoadScenes()
    {
        Application.LoadLevel("GameOver");
    }

    public void ResetShield()
    {
        have_shield = false;
    }

    void SlowTimeScaleGame()
    {
        Time.timeScale = 0f;
    }

    void ResetTimeScaleGame()
    {
        Time.timeScale = 1f;
    }

    
}
