using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriggers : MonoBehaviour
{

    public GameObject MaviGül;
    public GameObject dialogCanvas;
    public GameObject dialogManager;

    public bool isJumpscareCrossed;
    public bool isDumanSeen;


    [SerializeField] GameObject InteractPanel;
    [SerializeField] GameObject speakPanel;
    [SerializeField] GameObject speakSevgili;
    [SerializeField] GameObject GotoHomePanel;
    [SerializeField] GameObject MesaleInteract;
    [SerializeField] GameObject mezarlýgaGitInteract;
    [SerializeField] GameObject PickUpPanel;


    // Static instance of the class.
    private static PlayerTriggers _instance;
    // Public static property to access the instance.

    //SIGLETON PATTERN
    public static PlayerTriggers Instance
    {
        get
        {
            if (_instance == null)
            {
                // Find an existing instance of the singleton in the scene.
                _instance = FindObjectOfType<PlayerTriggers>();

                if (_instance == null)
                {
                    // Create a new GameObject if an instance does not already exist.
                    GameObject singletonObject = new GameObject(typeof(LanternLight).ToString());
                    _instance = singletonObject.AddComponent<PlayerTriggers>();
                }
            }
            return _instance;
        }
    }

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy the new instance.
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }



    }


    private void Start()
    {
        //  EvGameManager.Instance.onSleep += Sleep;
        isJumpscareCrossed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cin"))
        {
            speakPanel.SetActive(true);

        }

        if (other.gameObject.CompareTag("Sevgili") && ekme.totalekmeCount == 5)
        {
            speakSevgili.SetActive(true);

        }

        if (other.gameObject.CompareTag("CarMezarlýk"))
        {
            GotoHomePanel.SetActive(true);

        }

        if (other.gameObject.CompareTag("Mesale"))
        {
            MesaleInteract.SetActive(true);

        }

        if (other.gameObject.CompareTag("Jumpscare"))
        {
            isJumpscareCrossed = true;

        }


        if (other.gameObject.CompareTag("EvKapý"))
        {
            mezarlýgaGitInteract.SetActive(true);

        }

        if (other.gameObject.CompareTag("bul"))
        {
            PickUpPanel.SetActive(true);

        }

        if (other.gameObject.CompareTag("Duman"))
        {
            isDumanSeen = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Mesale"))
        {
            LanternLight.Instance.isRefreshed = true;

        }

        if (other.gameObject.CompareTag("OzelMesale"))
        {
            LanternLight.Instance.isRefreshed = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Cin"))
        {
            speakPanel.SetActive(false);

        }
        if (other.gameObject.CompareTag("Sevgili"))
        {
            speakSevgili.SetActive(false);

        }


        if (other.gameObject.CompareTag("Mesale"))
        {
            LanternLight.Instance.isRefreshed = false;
        }

        if (other.gameObject.CompareTag("OzelMesale"))
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




        if (other.gameObject.CompareTag("Jumpscare"))
        {
            isJumpscareCrossed = false;

        }

        if (other.gameObject.CompareTag("EvKapý"))
        {
            mezarlýgaGitInteract.SetActive(false);

        }

        if (other.gameObject.CompareTag("bul"))
        {
            PickUpPanel.SetActive(false);

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

                InteractPanel.SetActive(false);
            }
        }

        if (GotoHomePanel != null && GotoHomePanel.activeInHierarchy && gültopla.gülcounter == 5)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                GotoHomePanel.SetActive(false);
                AudioManager.Instance.playAudioCar();
                SceneManager.LoadScene("EvIkýncý");

            }
        }

        if (speakPanel != null && speakPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                Dialog.Instance.LoadAndStartDialog("Cin");
                speakPanel.SetActive(false);

            }
        }


        if (speakSevgili != null && speakSevgili.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                Dialog.Instance.LoadAndStartDialog("Sevgili");

            }

            if (Dialog.Instance.IsDialogFinished)
            {
                SceneManager.LoadScene("Son");
            }
        }

        if (mezarlýgaGitInteract != null && mezarlýgaGitInteract.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                SceneManager.LoadScene("MezarlýkIlk");

            }
        }

        if (PickUpPanel != null && PickUpPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                PickUpPanel.SetActive(false);
            }
        }

    }
}
