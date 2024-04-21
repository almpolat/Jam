using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public GameObject interactCanvasCin;
    public GameObject interactCanvasMaviGül;
    public GameObject MaviGül;
    public GameObject interactCanvasSevgili;
    public GameObject dialogCanvas;
    public GameObject dialogManager;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cin"))
        {
            interactCanvasCin.SetActive(true);
        }

        if (other.gameObject.CompareTag("Sevgili"))
        {
            interactCanvasSevgili.SetActive(true);
        }

        if (other.gameObject.CompareTag("MaviGül"))
        {
            interactCanvasMaviGül.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cin"))
        {
            interactCanvasCin.SetActive(false);
            dialogCanvas.SetActive(false);
            dialogManager.GetComponent<Dialog>().ResetDialog();
        }

        if (other.gameObject.CompareTag("Sevgili"))
        {
            interactCanvasSevgili.SetActive(false);
            dialogCanvas.SetActive(false);
            dialogManager.GetComponent<Dialog>().ResetDialog();
        }

        if (other.gameObject.CompareTag("MaviGül"))
        {
            interactCanvasMaviGül.SetActive(false);
            dialogCanvas.SetActive(false);
            dialogManager.GetComponent<Dialog>().ResetDialog();
        }
    }

    private void Update()
    {
        if (interactCanvasCin!=null && interactCanvasCin.activeInHierarchy) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogCanvas.SetActive(true);
                interactCanvasCin.SetActive(false);
            }
        }

        if (interactCanvasSevgili != null && interactCanvasSevgili.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogCanvas.SetActive(true);
                interactCanvasSevgili.SetActive(false);
            }
        }

        if (interactCanvasMaviGül != null && interactCanvasMaviGül.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                interactCanvasMaviGül.SetActive(false);
                MaviGül.SetActive(false) ;
            }
        }
    }
}
