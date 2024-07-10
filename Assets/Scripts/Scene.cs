using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToHide;
    [SerializeField] private float delayTime = 2.0f;
    [SerializeField] private GameObject[] objectsToActivate;

    //[SerializeField] private Button SOLO;


    private float timer = 0.0f;
    private int currentIndex = 0;
    private bool isActivated = false;

    public int difficultLevel;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Node");
        

        //GameObject[] foundedObjects = GameObject.FindGameObjectsWithTag("firewall");


        for (int i = 0; i < difficultLevel; i++)
        {
            int randomIndex = Random.Range(0, foundObjects.Length);
            GameObject randomObject = foundObjects[randomIndex];
            if (randomObject != null)
            {
                randomObject.tag = "enemy";
                Debug.Log("!!!");
            }
        }


    }

    public void ChangeScene(string sceneName) 
    { 
        SceneManager.LoadScene(sceneName); 
    }

    
    public void HideObjects()
    {
        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(false);
        }
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}

