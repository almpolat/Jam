using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{

    public GameObject MaviG�l;
    public GameObject dialogCanvas;
    public GameObject dialogManager;


    [SerializeField] GameObject InteractPanel;

    private void Start()
    {
        //  EvGameManager.Instance.onSleep += Sleep;

    }

    private void Sleep()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cin") || other.gameObject.CompareTag("Sevgili") || other.gameObject.CompareTag("MaviG�l"))
        {
            InteractPanel.SetActive(true);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Mesale"))
        {
            LanternLight.Instance.isRefreshed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cin") || other.gameObject.CompareTag("Sevgili") || other.gameObject.CompareTag("MaviG�l"))
        {
            InteractPanel.SetActive(false);
            dialogCanvas.SetActive(false);
            //dialogManager.GetComponent<Dialog>().ResetDialog();
        }


        if (other.gameObject.CompareTag("Mesale"))
        {
            LanternLight.Instance.isRefreshed = false;
        }

    }

    private void Update()
    {

        checkInputs();

    }

    private void checkInputs()
    {
        if (InteractPanel != null && InteractPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogCanvas.SetActive(true);
                InteractPanel.SetActive(false);
            }
        }
    }
}