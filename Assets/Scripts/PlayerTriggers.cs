using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriggers : MonoBehaviour
{

    public GameObject MaviGül;
    public GameObject dialogCanvas;
    public GameObject dialogManager;


    [SerializeField] GameObject InteractPanel;
    [SerializeField] GameObject GotoHomePanel;
    [SerializeField] GameObject MesaleInteract;

    private void Start()
    {
        //  EvGameManager.Instance.onSleep += Sleep;

    }

    private void Sleep()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cin") || other.gameObject.CompareTag("Sevgili") || other.gameObject.CompareTag("MaviGül"))
        {
            InteractPanel.SetActive(true);

        }

        if (other.gameObject.CompareTag("CarMezarlýk"))
        {
            GotoHomePanel.SetActive(true);

        }

        if (other.gameObject.CompareTag("Mesale"))
        {
            MesaleInteract.SetActive(true);

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
        if (other.gameObject.CompareTag("Cin") || other.gameObject.CompareTag("Sevgili") || other.gameObject.CompareTag("MaviGül"))
        {
            InteractPanel.SetActive(false);
            dialogCanvas.SetActive(false);
            //dialogManager.GetComponent<Dialog>().ResetDialog();
        }


        if (other.gameObject.CompareTag("Mesale"))
        {
            LanternLight.Instance.isRefreshed = false;
        }

        if (other.gameObject.CompareTag("CarMezarlýk"))
        {
            GotoHomePanel.SetActive(false);

        }


        if (other.gameObject.CompareTag("Mesale"))
        {
            MesaleInteract.SetActive(false);

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

        if (GotoHomePanel != null && GotoHomePanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                GotoHomePanel.SetActive(false);
                SceneManager.LoadScene(2);

            }
        }
    }
}
