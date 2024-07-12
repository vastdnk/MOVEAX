using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchEffect : MonoBehaviour
{
    public Material material;
    public float intensity = 5.5f;
    public float speed = 5.0f;

    private float time = 0.0f;
    private bool isGlitching = false;

    void Start()
    {
        if (material == null)
        {
            material = new Material(Shader.Find("Hidden/GlitchEffect"));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGlitching = true;
            time = 0.0f;
        }

        if (isGlitching)
        {
            time += Time.deltaTime * speed;
            material.SetFloat("_Intensity", Mathf.Sin(time) * intensity);

            if (time > Mathf.PI)
            {
                isGlitching = false;
                material.SetFloat("_Intensity", 0.0f);
            }
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
