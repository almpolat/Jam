using System.Collections;
using TMPro;
using UnityEngine;
public class ekme : MonoBehaviour
{
    // Counter to keep track of triggers
    public static int ekmecounter = 0;

    // Reference to the TMP Text component, assigned in the inspector
    public TextMeshProUGUI textComponent;

    // Total number of gül objects
    private static int totalekmeCount = 5;

    // Game objects to activate/deactivate based on ekmecounter value
    public GameObject sarýGülObjesi;
    public GameObject objectToActivate1;
    public GameObject objectToActivate2;
    public GameObject objectToHide;

    private bool isEkili = false;

    private void Start()
    {
        ekmecounter = 0;

        // Ensure object to hide is active
        if (objectToHide != null)
        {
            objectToHide.SetActive(true);
        }
        if (textComponent != null)
        {
            textComponent.gameObject.SetActive(true);
            textComponent.text = ekmecounter + "/" + totalekmeCount + " cicek ekildi";
        }
    }
    private void Awake()
    {
        // Start with the objects inactive
        sarýGülObjesi.SetActive(false);
        objectToActivate1.SetActive(false);
        objectToActivate2.SetActive(false);


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

    private void Update()
    {

    }

    private IEnumerator WaitForKeyPress()
    {
        // Wait until the 'E' key is pressed
        while (!Input.GetKeyDown(KeyCode.E))
        {
            yield return null;
        }

        if (!isEkili)
        {
            // Show this object
            sarýGülObjesi.SetActive(true);

            // Increment the counter
            ekmecounter++;
            Debug.Log("ekmecounter: " + ekmecounter);

            // Update the TMP Text content
            UpdateekmecounterText();

            // Activate objects if ekmecounter equals totalekmeCount
            if (ekmecounter == 5)
            {

                Dialog.Instance.LoadAndStartDialog("CýceklerEkýldý");


                objectToActivate1.SetActive(true);
                objectToActivate2.SetActive(true);



                if (objectToHide != null)
                {
                    objectToHide.SetActive(false);
                }
            }

            isEkili = false;
        }

    }

    private void UpdateekmecounterText()
    {
        // Update the TMP text to show the current counter value
        if (textComponent != null)
        {
            textComponent.text = ekmecounter + "/" + totalekmeCount + " ekilen cicek";

            // Hide the TMP text if ekmecounter equals totalekmeCount
            if (ekmecounter == totalekmeCount)
            {
                textComponent.gameObject.SetActive(false);
            }
        }
    }
}
