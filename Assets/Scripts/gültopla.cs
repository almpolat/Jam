using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class g�ltopla : MonoBehaviour
{
    // Counter to keep track of triggers
    private static int g�lcounter = 0;
    public GameObject ektext;
    private void Start()
    {
        // Oyun ba�lad���nda g�rev objesini inaktif hale getir
        if (ektext != null)
        {
            ektext.SetActive(false);
        }
    }

    // Reference to the TMP Text component, shared among all instances
    private static TextMeshProUGUI g�lcounterText;

    // Reference to the TMP Text component, assigned in the inspector
    public TextMeshProUGUI textComponent;

    // Total number of g�l objects
    private static int totalG�lCount = 3;

    private void Awake()
    {
        // Assign the TMP Text component if it's not already assigned
        if (g�lcounterText == null && textComponent != null)
        {
            g�lcounterText = textComponent;
            UpdateG�lcounterText(); // Initialize the TMP text with the starting value
        }
    }


    private void Update()
    {
        if (g�lcounter == 1)
        {
            Dialog.Instance.LoadAndStartDialog("G�lTopland�");

            StartCoroutine(WaitForDialogFinish());
            g�lcounter = 0;
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



    private IEnumerator WaitForDialogFinish()
    {
        //Waits to dialog finish
        yield return new WaitForSeconds(3);

        //Than go to Ev scene
        SceneManager.LoadScene(2);
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
        Debug.Log("G�lcounter: " + g�lcounter);

        // Update the TMP Text content
        UpdateG�lcounterText();
    }

    private void UpdateG�lcounterText()
    {
        // Update the TMP text to show the current counter value
        if (g�lcounterText != null)
        {
            g�lcounterText.text = g�lcounter + "/" + totalG�lCount + " toplanan g�l";

            // Hide the TMP text if g�lcounter equals totalG�lCount
            if (g�lcounter == totalG�lCount)
            {
                g�lcounterText.gameObject.SetActive(false);
                ektext.SetActive(true);
            }
        }
    }
}