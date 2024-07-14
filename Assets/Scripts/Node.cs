using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Node : MonoBehaviour
{
    public GameObject node;
    public GameObject syncObject;

    


    [SerializeField] Sync sync;
    public bool activated = false;
    public bool blocked = true;

    public bool nearStartNode;             // для того, чтобы не супрессор не прокал сразу на стартовых нодах
    public bool preReady = false;
    

    public Animator animator;

    [Header("Enemies")]
    [SerializeField] bool antivirus;
    [SerializeField] bool supressor;
    [SerializeField] bool restoration;
    [SerializeField] bool firewall;


    public GameObject[] nearestObjects;


    Color color_activated;
    Color color_standby;
    Color color_blocked;
    Color color_sync;

    Color color_sync_preready;


    //public AudioClip din;
    //public AudioSource audioObject;


    public int strengthCode = 50;
    int digit;


    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = color_activated;


        if (tag != "enemy")
        {
            animator.SetBool("Selected", true);
        } else
        {
            enemyPoints();
        }


        if (blocked == false)
        {          
            FindNearestSync();
            blocked = true;
            //audioObject.PlayOneShot(din);
            //GetComponent<SpriteRenderer>().color = Color.gray;
        }




    }
    
    void Start()
    {
        UnityEngine.ColorUtility.TryParseHtmlString("#6D221A", out color_activated);         //стандартный красный проходной
        UnityEngine.ColorUtility.TryParseHtmlString("#4D4D4D", out color_sync);
        UnityEngine.ColorUtility.TryParseHtmlString("#4D4D4D", out color_standby);
        UnityEngine.ColorUtility.TryParseHtmlString("#092b37", out color_blocked);           //заблокировано возле фаерволла
        UnityEngine.ColorUtility.TryParseHtmlString("#00E5DD", out color_sync_preready);     //подготовлен к активации


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
            GetComponent<SpriteRenderer>().color = Color.gray;
        }        
    }

    

    void FindNearestSync() 
    {
        foreach (var item in nearestObjects)
        {
            if (item.GetComponent<SpriteRenderer>().color == color_sync_preready) // если подготовлено, окрашивается в красный
            {
                item.GetComponent<SpriteRenderer>().color = color_activated;
            }
            
           
        }
        foreach (var item in nearestObjects)
        {

            if (gameObject.tag != "enemy")
            {
                if (item.GetComponent<SpriteRenderer>().color != color_sync_preready & item.GetComponent<SpriteRenderer>().color != color_activated)
                {
                    item.GetComponent<SpriteRenderer>().color = color_sync_preready;
                    item.tag = "Sync";
                }
                //Debug.Log(nearestObjects.Length);
            } else
            {
                if (item.tag != "Sync")
                //if (item.tag == "Sync")
                {
                    item.tag = "tempDesync";
                    item.GetComponent<SpriteRenderer>().color = color_blocked;
                }
                else
                {
                    item.GetComponent<SpriteRenderer>().color = color_blocked;
                }
                
                
            }
                  
        }

        gameObject.GetComponent<Node>().activated = true;

    }
    void MyCollisions()
    {
        foreach (var item in nearestObjects)
        {
            if (item.tag == "Sync" & gameObject.tag != "blockedNode") //включает с анимацией и подготавливает ближайшие ноды к активации
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = true;
                gameObject.GetComponent<Node>().blocked = false;
                gameObject.GetComponent<Node>().preReady = true;
                animator.SetBool("Nears", true);
            }


            if (item.tag == "tempDesync") // затрагивает ноду, связанную с ветками tempDesync
            {
                gameObject.GetComponent<Node>().blocked = true;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                

                if (gameObject.tag != "enemy")
                {
                    gameObject.tag = "blockedNode";
                    gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
                }
                               
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
            //gameObject.GetComponent<SpriteRenderer>().color = color_blocked; //
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





    void enemyPoints()
    {
        if (gameObject.tag == "enemy")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            animator.SetBool("Firewall", true);
        }
    }



    // Update is called once per frame
    void Update() 
    {
        MyCollisions();

    }

    

}

    
