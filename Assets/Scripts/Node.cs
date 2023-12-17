using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject node;

    public GameObject syncObject;
    [SerializeField] Sync sync;
    public bool activated = false;
    public bool blocked = true;
    public bool preReady = false;
    public bool ml_Read = false;

    public Animator animator;


    public GameObject[] nearestObjects;
    public LayerMask m_LayerMask;


    Color color_activated;
    Color color_standby;
    Color color_blocked;
    Color color_sync;

    //public AudioClip din;
    //public AudioSource audioObject;


    public int strengthCode = 50;
    int digit;


    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = color_activated;
        animator.SetBool("Selected", true);


        if (blocked == false)
        {          
            FindNearestSync();
            blocked = true;
            //audioObject.PlayOneShot(din);
        }

        firewallPoints();

    }

    void Start()
    {

        Chance();

        UnityEngine.ColorUtility.TryParseHtmlString("#6D221A", out color_activated);
        UnityEngine.ColorUtility.TryParseHtmlString("#4D4D4D", out color_sync);
        UnityEngine.ColorUtility.TryParseHtmlString("#4D4D4D", out color_standby);
        UnityEngine.ColorUtility.TryParseHtmlString("#092b37", out color_blocked);

        gameObject.GetComponent<SpriteRenderer>().color = color_standby;

        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 0.5f); // NEAREST SYNC OBJECTS
        foreach (var nearObj in hitColliders)
        {
            nearestObjects = nearestObjects.Append(nearObj.gameObject).ToArray();
            //nearObj.GetComponent<CircleCollider2D>().enabled = true;
            
        }


        if (activated == true || gameObject.tag == "start")
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (blocked == true)
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }        
    }

    public void Back(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void FindNearestSync() 
    {
        foreach (var item in nearestObjects)
        {
            if (item.GetComponent<SpriteRenderer>().color == Color.white)
            {
                item.GetComponent<SpriteRenderer>().color = color_activated;
            }
            
            //if (tag == "start")
            //{
            //    item.GetComponent<SpriteRenderer>().color = Color.red;
            //}
        }
        foreach (var item in nearestObjects)
        {

            if (gameObject.tag != "firewall")
            {
                if (item.GetComponent<SpriteRenderer>().color != Color.white & item.GetComponent<SpriteRenderer>().color != color_activated)
                {
                    item.GetComponent<SpriteRenderer>().color = Color.white;
                    item.tag = "Sync";
                }
                Debug.Log(nearestObjects.Length);
            } else
            {
                if (item.tag != "Sync")
                {
                    item.tag = "tempDesync";
                    item.GetComponent<SpriteRenderer>().color = Color.black;
                }
                
            }
                  
        }



        gameObject.GetComponent<Node>().activated = true;

    }
    void MyCollisions()
    {
        foreach (var item in nearestObjects)
        {
            if (item.tag == "Sync" & gameObject.tag != "blockedNode")
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = true;
                gameObject.GetComponent<Node>().blocked = false;
                gameObject.GetComponent<Node>().preReady = true;
                animator.SetBool("Nears", true);
            }
            
            if (item.tag == "tempDesync")
            {
                gameObject.GetComponent<Node>().blocked = true;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
                gameObject.tag = "blockedNode";                
            }
            
        }
        if (gameObject.GetComponent<Node>().activated == true)
        {
            gameObject.GetComponent<Node>().blocked = true;
        }

        if (gameObject.tag == "blockedNode")
        {
            gameObject.GetComponent<Node>().blocked = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false; 
            gameObject.GetComponent<SpriteRenderer>().color = color_blocked;
            gameObject.GetComponent<Node>().preReady = false;

            foreach (var item in nearestObjects)
            {
                item.GetComponent<SpriteRenderer>().color = color_blocked;
            }
        }


        if (preReady == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }


    }



    void firewallPoints()
    {
        if (gameObject.tag == "firewall")
        {
            //Transform frwlChild = transform.GetChild(0);
            //frwlChild.gameObject.SetActive(true);

            gameObject.GetComponent<SpriteRenderer>().color = Color.red;


        }
    }




    void Chance()
    {
        digit = Random.Range(0, 101);
        if (digit <= 35)
        {
            gameObject.tag = "firewall";
        }
    }







    // Update is called once per frame
    void Update() 
    {
        MyCollisions();
    }

    

}

    
