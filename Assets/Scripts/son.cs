using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class son : MonoBehaviour
{
    public GameObject soncanvas;

    void Start()
    {
        Dialog.Instance.LoadAndStartDialog("Son");

        // Mouse imlecini görünür hale getir ve kilitlenmesini önle
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        // Eðer IsDialogFinished bir deðiþken ya da bir özellik ise, doðru þekilde kontrol edilmeli.
        if (Dialog.Instance.IsDialogFinished)
        {
            soncanvas.SetActive(true);
        }
    }
}