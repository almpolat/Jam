using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hayalet2 : MonoBehaviour
{
    public GameObject objectToShow; // Gösterilecek obje
    private bool playerInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            StartCoroutine(ShowObject());
        }
    }

    private IEnumerator ShowObject()
    {
        if (objectToShow != null)
        {
            objectToShow.SetActive(true); // Obje görünür hale gelir
            yield return new WaitForSeconds(2); // 3 saniye bekle
            objectToShow.SetActive(false); // Obje tekrar gizlenir
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
}
