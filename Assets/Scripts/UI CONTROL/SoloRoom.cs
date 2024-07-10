using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoloRoom : MonoBehaviour
{
    public GameObject loadingMap, soloRoom, floors, mainFrame;

    private GameObject backButton;
    [SerializeField] private GameObject[] objectsToActivate;
    [SerializeField] private float delayTime = 2.0f;


    private float timer = 0.0f;
    private int currentIndex = 0;
    private bool isActivated = false;
    public bool loadingMapComplete;

    void Start()
    {
        //loadingMap = GameObject.Find("LoadingMap");
        //levelsLayer = GameObject.Find("Floors");
        soloRoom = GameObject.Find("SoloRoom");
        backButton = GameObject.Find("BackBtn");
        //mainFrameScene = GameObject.Find("MainFrame");
    }


    void loadPanel()
    {
        if (!isActivated)
        {
            timer += Time.deltaTime;

            if (timer >= delayTime && currentIndex < objectsToActivate.Length)
            {
                objectsToActivate[currentIndex].SetActive(true);
                currentIndex++;
                timer = 0.0f;
            }

            if (currentIndex == objectsToActivate.Length & objectsToActivate.Length != 0)
            {
                isActivated = true;
                loadingMapComplete = true;
                loadingMap.SetActive(false);
                Debug.Log("dsds");
                //Destroy(loadingMap);
            }
        }
    }


    public void GetBackToMain()
    {
        mainFrame.GetComponent<CanvasGroup>().alpha = 1;
        mainFrame.active = true;
        soloRoom.GetComponent<CanvasGroup>().alpha = 0;
        soloRoom.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


    void activeInterface()
    {
          if (soloRoom.GetComponent<CanvasGroup>().alpha == 1)
          {
                if(loadingMap != null)
                {
                    loadingMap.SetActive(true);

                    loadPanel();
                    if (loadingMapComplete == true)
                    {
                        loadingMap.SetActive(false);
                    }

                }

                if (loadingMap.active == false) { 
                    floors.GetComponent<CanvasGroup>().alpha = 1;
                    floors.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
        }
    }

// Update is called once per frame

    void Update()
    {
        activeInterface();
    }
}
