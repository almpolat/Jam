using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
    // G�sterilecek public obje
    public GameObject objectToShow;

    private void OnTriggerEnter(Collider other)
    {
        // E�er tetikleyen obje "Player" tagine sahipse
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowObjectTemporarily());
        }
    }

    private IEnumerator ShowObjectTemporarily()
    {
        if (objectToShow != null)
        {
            // Obje g�r�n�r hale gelir
            objectToShow.SetActive(true);

            // Yar�m saniye bekle
            yield return new WaitForSeconds(0.5f);

            // Obje tekrar gizlenir
            objectToShow.SetActive(false);
        }
    }
}
