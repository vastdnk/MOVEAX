using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillerRand : MonoBehaviour
{
    int value;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }


    public void rndTxt()
    {
        value = Random.Range(1111, 9999);
        txt.text = value.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rndTxt();
    }
}
