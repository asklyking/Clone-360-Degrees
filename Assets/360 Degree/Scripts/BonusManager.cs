using UnityEngine;
using System.Collections;
//using UnityEngine.Advertisements;

public class BonusManager : MonoBehaviour
{

    public GameObject ring;


    public GameObject double_ruby_dialog;


    string GameID = "1021024";
    // Use this for initialization
    void Start()
    {
        double_ruby_dialog.SetActive(false);

        //Advertisement.Initialize(GameID);

        Invoke("showDoubleRuby", 2f);

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 1f) * 500 * (1 / Time.timeScale));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x >= Screen.width / 2)
            {
                ring.transform.eulerAngles = new Vector3(0, 0, ring.transform.eulerAngles.z + 1f);
            }
            else
            {
                ring.transform.eulerAngles = new Vector3(0, 0, ring.transform.eulerAngles.z - 1f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ruby")
        {
            Destroy(other.gameObject);
        }
    }

    public void showDoubleRuby()
    {
        double_ruby_dialog.SetActive(true);
        Time.timeScale = 0;
    }

    public void showUnityAds()
    {
        //if (Advertisement.isReady()) { Advertisement.Show(); }
    }
}
