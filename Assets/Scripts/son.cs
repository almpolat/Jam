using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class son : MonoBehaviour
{
    public GameObject soncanvas;

    void Start()
    {
        Dialog.Instance.LoadAndStartDialog("Son");

        // Mouse imlecini g�r�n�r hale getir ve kilitlenmesini �nle
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        // E�er IsDialogFinished bir de�i�ken ya da bir �zellik ise, do�ru �ekilde kontrol edilmeli.
        if (Dialog.Instance.IsDialogFinished)
        {
            soncanvas.SetActive(true);
        }
    }
}