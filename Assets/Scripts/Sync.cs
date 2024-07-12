using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class Sync : MonoBehaviour
{
    public bool activated = false;
    public Animator animator;

    UnityEngine.Color color_activated;
    

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.ColorUtility.TryParseHtmlString("#41F5F5", out color_activated);
    }


    public void SyncCollisions()
    {
        

    }


    // Update is called once per frame
    void Update()
    {
        //if (tag == "Sync")
        //{
        //    animator.SetBool("Activated", true);
        //    if (gameObject.GetComponent<SpriteRenderer>().color != color_activated)
        //    {
        //        gameObject.GetComponent<SpriteRenderer>().color = color_activated;
        //    }
        //}
        
    }
}
