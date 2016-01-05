using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject Level;
    public GameObject Pause;
    public GameObject Ring;
    public Text txt_score;
    public Text txt_ruby;

    public GameObject[] nails;


    //public static bool destroyed_diamond = false;
    public static bool active_shield = false;
    public static bool active_ruby = false;
    public static bool touch_ring = false;
    public static int Score = 0;
    public static int Ruby_Num = 0;
    public static int Ruby_Total = 0;
    public static bool pause_game ;

    int ruby_set =0;
	// Use this for initialization
	void Start () {

        Level.SetActive(true);
        Pause.SetActive(false);
        //destroyed_diamond = false;
        pause_game = false;
        Score = 0;
        Ruby_Num = 0;

        //nails = GameObject.FindGameObjectsWithTag("Nail");

        for (int i = 0; i < nails.Length; i++)
        {
            nails[i].SetActive(false);
        }

	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause_game = true;
        }
        
        /*
        if (destroyed_diamond == true)
        {
            position_diamond = Random.RandomRange(0, 4);

            array_diamond[position_diamond].SetActive(true);
            destroyed_diamond = false;
        }
        */
	    if(Input.GetMouseButton(0) && pause_game == false)
        {
            if (Input.mousePosition.x >= Screen.width/2)
            {
                Ring.transform.eulerAngles = new Vector3(0, 0, Ring.transform.eulerAngles.z + 1f);
            }
            else
            {
                Ring.transform.eulerAngles = new Vector3(0, 0, Ring.transform.eulerAngles.z - 1f);
            }
        }

        if( Score %11 == 0 && Score != 0)
        {
            active_shield = true;
        }

        if(Score % 7 == 0 && Score !=0)
        {
            active_ruby = true;
        }

        if(active_ruby == true)
        {
            Invoke("DeActiveRuby", 1f);
        }
        
        if(touch_ring == true)
        {
            Invoke("ResetNail", 0.1f);
        }
        // update score
        txt_score.text = "" + Score;
        // update ruby
        txt_ruby.text = "x " + Ruby_Num;


        // update pausegame
        if(pause_game == true)
        {
            Pause.SetActive(true);
            Level.transform.localScale = new Vector3(0,0,0);
            Time.timeScale = 0;
        }
        else
        {
            Pause.SetActive(false);
            Level.transform.localScale = new Vector3(1, 1, 1);
            Time.timeScale = 1;
        }
	}

    public void LoadScenes(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }

    void DeActiveRuby()
    {
        active_ruby = false;
    }

    void ResetNail()
    {
        for (int i = 0; i < nails.Length; i++)
        {
            nails[i].SetActive(false);
        }
        int pos1 = Random.Range(1, nails.Length/3);
        int pos2 = Random.Range(nails.Length/3, 2 * nails.Length/3);
        int pos3 = Random.Range(2 * nails.Length / 3,nails.Length-3);


        nails[pos1].SetActive(true);
        nails[pos1 + 1].SetActive(true);
        nails[pos1 + 2].SetActive(true);

        nails[pos2].SetActive(true);
        nails[pos2 + 1].SetActive(true);
        nails[pos2 + 2].SetActive(true);

        nails[pos3].SetActive(true);
        nails[pos3 + 1].SetActive(true);
        nails[pos3 + 2].SetActive(true);


        touch_ring = false;
    }


    public void PauseGame()
    {
        pause_game = !pause_game;
    }
}
