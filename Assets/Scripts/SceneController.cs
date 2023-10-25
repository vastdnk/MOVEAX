using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject popupExitConfirmed;
    [SerializeField] private Button exitB;
    GameObject board;
    
    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("MainBoard");
    }



    public void popupExit() 
    {    
        popupExitConfirmed.SetActive(true);
        board.SetActive(false);
    }


    void OnMouseDown()
    {
        

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
