using System.Collections;
using TMPro;
using UnityEngine;

public class g�ltopla : MonoBehaviour
{
    // Counter to keep track of triggers
    public static int g�lcounter = 0;
    public GameObject Hideprefab;
    public GameObject Activeprefab;




    // Reference to the TMP Text component, shared among all instances
    private static TextMeshProUGUI g�lcounterText;

    // Reference to the TMP Text component, assigned in the inspector
    public TextMeshProUGUI textComponent;

    // Total number of g�l objects
    private static int totalG�lCount = 5;


    private void Start()
    {
        g�lcounter = 0;


        // Assign the TMP Text component if it's not already assigned
        if (g�lcounterText == null && textComponent != null)
        {
            g�lcounterText = textComponent;
            UpdateG�lcounterText(); // Initialize the TMP text with the starting value
        }
    }
    private void Awake()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the 'Player' tag
        if (other.CompareTag("Player"))
        {
            // Listen for the 'E' key press
            StartCoroutine(WaitForKeyPress());
        }
    }

    private IEnumerator WaitForKeyPress()
    {
        // Wait until the 'E' key is pressed
        while (!Input.GetKeyDown(KeyCode.E))
        {
            yield return null;
        }

        // Hide this object
        gameObject.SetActive(false);

        // Increment the counter
        g�lcounter++;
        Debug.Log("Cicekcounter: " + g�lcounter);

        // Update the TMP Text content
        UpdateG�lcounterText();
    }

    private void UpdateG�lcounterText()
    {
        // Update the TMP text to show the current counter value
        if (g�lcounterText != null)
        {
            g�lcounterText.text = g�lcounter + "/" + totalG�lCount + " toplanan cicek";

            // Hide the TMP text if g�lcounter equals totalG�lCount
            if (g�lcounter == totalG�lCount)
            {
                Dialog.Instance.LoadAndStartDialog("G�lTopland�");
                //goToHomePanel.SetActive(true);
                g�lcounterText.gameObject.SetActive(false);
                Activeprefab.SetActive(true);
                Hideprefab.SetActive(false);
            }
        }
    }
}