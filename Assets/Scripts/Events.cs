using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
   
    public GameObject MaviGül;
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
        if (other.gameObject.CompareTag("Cin") || other.gameObject.CompareTag("Sevgili") || other.gameObject.CompareTag("MaviGül"))
        {
           InteractPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cin") || other.gameObject.CompareTag("Sevgili") || other.gameObject.CompareTag("MaviGül"))
        {
            InteractPanel.SetActive(false);
            dialogCanvas.SetActive(false);
            dialogManager.GetComponent<Dialog>().ResetDialog();
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
