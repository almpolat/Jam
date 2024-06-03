using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    [Header("Dialog Settings")]
    public TextMeshProUGUI dialogText;
    public float textSpeed;
    public GameObject dialogCanvas;

    private DialogData currentDialog;
    private int sentenceIndex;

    // Singleton pattern
    private static Dialog _instance;

    public static Dialog Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Dialog>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(Dialog).ToString());
                    _instance = singletonObject.AddComponent<Dialog>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        ContinueDialog();
        CloseDialogWhenFinished();

        if (Input.GetKey(KeyCode.Space))
        {
            LoadAndStartDialog("HomeDialog");
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Car"))
            {
                LoadAndStartDialog("Araba");
            }
            else if (other.CompareTag("Player"))
            {
                GameObject[] cinObjects = GameObject.FindGameObjectsWithTag("Cin");
                foreach (GameObject cin in cinObjects)
                {
                    if (other.gameObject == cin)
                    {
                        LoadAndStartDialog("Hayalet");
                        break;
                    }
                }
            }
        }
    }

    public void StartSpecificDialog(DialogData specificDialog)
    {
        dialogCanvas.SetActive(true);
        StopAllCoroutines();
        dialogText.text = string.Empty;
        currentDialog = specificDialog;
        sentenceIndex = 0;
        StartCoroutine(TypeLine());
    }

    public void LoadAndStartDialog(string dialogName)
    {
        DialogData dialogData = Resources.Load<DialogData>("DialogData/" + dialogName);
        if (dialogData != null)
        {
            StartSpecificDialog(dialogData);
        }
        else
        {
            Debug.LogError("DialogData not found: " + dialogName);
        }
    }

    private void CloseDialogWhenFinished()
    {
        if (currentDialog != null && dialogText.text == currentDialog.dialogLines[currentDialog.dialogLines.Length - 1])
        {
            dialogCanvas.SetActive(false);
            StopAllCoroutines();
            dialogText.text = string.Empty;
            currentDialog = null;
            sentenceIndex = 0;
        }
    }

    private void ContinueDialog()
    {
        if (Input.GetMouseButtonDown(0) && currentDialog != null)
        {
            if (dialogText.text == currentDialog.dialogLines[sentenceIndex])
            {
                NextSentence();
            }
            else
            {
                StopAllCoroutines();
                dialogText.text = currentDialog.dialogLines[sentenceIndex];
            }

            if (dialogText.text == currentDialog.dialogLines[currentDialog.dialogLines.Length - 1])
            {
                sentenceIndex = 0;
            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentDialog.dialogLines[sentenceIndex].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextSentence()
    {
        if (sentenceIndex < currentDialog.dialogLines.Length - 1)
        {
            sentenceIndex++;
            dialogText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogText.text = string.Empty;
        }
    }
}
