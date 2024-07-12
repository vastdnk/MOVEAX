using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolsByOne : MonoBehaviour
{
    [SerializeField] Text txt;
    [SerializeField] private string textfield;
    [SerializeField] private float del;
    void Start()
    {
        StartCoroutine(c_Output(textfield, del));
    }

    IEnumerator c_Output(string str, float delay)
    {
        foreach (var sym in str)
        {
            print(sym);

            txt.text += sym;

            yield return new WaitForSeconds(delay);
        }
    }
}
