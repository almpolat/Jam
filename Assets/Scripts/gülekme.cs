using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject sar�G�lObjesi; // Sar� g�l objesini Unity Editor'den s�r�kleyip b�rak�n

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the 'Player' tag
        if (other.CompareTag("Player"))
        {
            // Activate the sar�G�lObjesi
            sar�G�lObjesi.SetActive(true);
        }
    }

    private void Start()
    {
        // Deactivate the sar�G�lObjesi at the beginning
        sar�G�lObjesi.SetActive(false);
    }
}