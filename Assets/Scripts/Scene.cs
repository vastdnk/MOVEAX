using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Node");
        int randomIndex = Random.Range(0, foundObjects.Length);
        GameObject randomObject = foundObjects[randomIndex];

        if (randomObject != null)
        {
            randomObject.tag = "firewall";
        }

    }

    public void ChangeScene(string sceneName) 
    { 
        SceneManager.LoadScene(sceneName); 
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
