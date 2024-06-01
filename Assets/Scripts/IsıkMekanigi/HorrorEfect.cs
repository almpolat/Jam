using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorEfect : MonoBehaviour
{
    [SerializeField] private Renderer glowRenderer;
    private Material glowMaterial;
    private Color emissionColor = Color.white;
    Color baseEmissionColor;
    [SerializeField] private Light lanternLight;


    float scale;
    // Start is called before the first frame update
    void Start()
    {
        glowRenderer = GetComponent<Renderer>();
        glowMaterial = glowRenderer.material;

        // Get the current emission color
         baseEmissionColor = glowMaterial.GetColor("_EmissionColor");

    }

    // Update is called once per frame
    void Update()
    {
        scale = LanternLight.Instance.lightScale;
        Effects();
    }

    void Effects()
    {
        // Enable the emission keyword (required for Standard Shader)
        glowRenderer.material.EnableKeyword("_EMISSION");

        

        // Set the new emission color with the desired intensity
        Color finalEmissionColor = baseEmissionColor * Mathf.LinearToGammaSpace(scale);
        glowMaterial.SetColor("_EmissionColor", finalEmissionColor);

        lanternLight.intensity = scale * 10;
    }

}
