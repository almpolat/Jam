using System.Collections;
using TMPro;
using UnityEngine;

public class gültopla : MonoBehaviour
{
    // Counter to keep track of triggers
    public static int gülcounter = 0;
    public GameObject Hideprefab;
    public GameObject Activeprefab;




    // Reference to the TMP Text component, shared among all instances
    private static TextMeshProUGUI gülcounterText;

    // Reference to the TMP Text component, assigned in the inspector
    public TextMeshProUGUI textComponent;

    // Total number of gül objects
    private static int totalGülCount = 5;


    private void Start()
    {
        gülcounter = 0;


        // Assign the TMP Text component if it's not already assigned
        if (gülcounterText == null && textComponent != null)
        {
            gülcounterText = textComponent;
            UpdateGülcounterText(); // Initialize the TMP text with the starting value
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
        gülcounter++;
        Debug.Log("Cicekcounter: " + gülcounter);

        // Update the TMP Text content
        UpdateGülcounterText();
    }

    private void UpdateGülcounterText()
    {
        // Update the TMP text to show the current counter value
        if (gülcounterText != null)
        {
            gülcounterText.text = gülcounter + "/" + totalGülCount + " toplanan cicek";

            // Hide the TMP text if gülcounter equals totalGülCount
            if (gülcounter == totalGülCount)
            {
                Dialog.Instance.LoadAndStartDialog("GülToplandý");
                //goToHomePanel.SetActive(true);
                gülcounterText.gameObject.SetActive(false);
                Activeprefab.SetActive(true);
                Hideprefab.SetActive(false);
            }
        }
    }
}