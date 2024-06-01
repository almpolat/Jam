using UnityEngine;

public class LightAdjuster : MonoBehaviour
{
    [SerializeField]
    private Renderer glowRenderer;
    private Material glowMaterial;


    [SerializeField]
    private Light lanternLight;
    private Color baseEmissionColor;

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

        Effects();
    }

    void Effects()
    {
        //Get scale from lantern class
        scale = LanternLight.Instance.lightScale;

        // Enable the emission keyword (required for Standard Shader)
        glowRenderer.material.EnableKeyword("_EMISSION");


        // Set the new emission color with the desired intensity
        Color finalEmissionColor = baseEmissionColor * Mathf.LinearToGammaSpace(scale);

        // Set the glows color with changing scale
        glowMaterial.SetColor("_EmissionColor", finalEmissionColor);

        // Set the spot light Intensity according to the scale
        lanternLight.intensity = scale * 20;
    }

}
