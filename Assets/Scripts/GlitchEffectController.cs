using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlitchEffectController : MonoBehaviour
{
    public Image glitchImage;
    public RectTransform glitchPanel;
    // Start is called before the first frame update
    void Start()
    {
        glitchPanel = GetComponent<RectTransform>();
        glitchImage = GetComponentInChildren<Image>();
    }

    public void Glitch()
    {
        StartCoroutine(GlitchCoroutine());
    }

    IEnumerator GlitchCoroutine()
    {
        float duration = 0.1f;
        float intensity = 0.1f;
        float time = 0;

        while (time < duration)
        {
            float x = Random.Range(-intensity, intensity);
            float y = Random.Range(-intensity, intensity);
            float alpha = Random.Range(0.5f, 1f);
            glitchPanel.anchoredPosition = new Vector2(x, y);
            glitchImage.color = new Color(1, 1, 1, alpha);
            yield return null;
            time += Time.deltaTime;
        }

        glitchPanel.anchoredPosition = Vector2.zero;
        glitchImage.color = Color.white;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Glitch();
    }
}
