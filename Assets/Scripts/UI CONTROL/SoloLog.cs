using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoloLog : MonoBehaviour
{

    [SerializeField] private Button soloButton;
    public GameObject mainFrameScene;
    public GameObject soloRoom, mainInterface, loadingMap;

    void Start()
    {
        mainFrameScene = GameObject.Find("MainFrame");
        soloRoom = GameObject.Find("SoloRoom");
        mainInterface = GameObject.Find("MainInterface");
        loadingMap = GameObject.Find("LoadingMap");

    }

    // Start is called before the first frame update
    
    public void HideObject()
    {
        
      if (mainFrameScene.GetComponent<CanvasGroup>().alpha == 1)
        {
            mainFrameScene.GetComponent<CanvasGroup>().alpha = 0;
            soloRoom.GetComponent<CanvasGroup>().alpha = 1;
            soloRoom.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
