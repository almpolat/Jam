using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ekme : MonoBehaviour
{
    // Counter to keep track of triggers
    private static int ekmecounter = 0;

    // Reference to the TMP Text component, assigned in the inspector
    public TextMeshProUGUI textComponent;

    // Total number of g�l objects
    private static int totalekmeCount = 5;

    // Game objects to activate/deactivate based on ekmecounter value
    public GameObject sar�G�lObjesi;
    public GameObject objectToActivate1;
    public GameObject objectToActivate2;
    public GameObject objectToHide;

    private void Awake()
    {
        // Start with the objects inactive
        sar�G�lObjesi.SetActive(false);
        objectToActivate1.SetActive(false);
        objectToActivate2.SetActive(false);

        // Ensure object to hide is active
        if (objectToHide != null)
        {
            objectToHide.SetActive(true);
        }
        if (textComponent != null)
        {
            textComponent.gameObject.SetActive(true);
            textComponent.text = ekmecounter + "/" + totalekmeCount + " g�l ekildi";
        }
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

        // Show this object
        sar�G�lObjesi.SetActive(true);

        // Increment the counter
        ekmecounter++;
        Debug.Log("ekmecounter: " + ekmecounter);

        // Update the TMP Text content
        UpdateekmecounterText();

        // Activate objects if ekmecounter equals totalekmeCount
        if (ekmecounter == totalekmeCount)
        {
            objectToActivate1.SetActive(true);
            objectToActivate2.SetActive(true);

            if (objectToHide != null)
            {
                objectToHide.SetActive(false);
            }
        }
    }

    private void UpdateekmecounterText()
    {
        // Update the TMP text to show the current counter value
        if (textComponent != null)
        {
            textComponent.text = ekmecounter + "/" + totalekmeCount + " ekilen g�l";

            // Hide the TMP text if ekmecounter equals totalekmeCount
            if (ekmecounter == totalekmeCount)
            {
                textComponent.gameObject.SetActive(false);
            }
        }
    }
}
