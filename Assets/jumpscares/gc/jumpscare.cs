using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
    // Gösterilecek public obje
    public GameObject objectToShow;

    private void OnTriggerEnter(Collider other)
    {
        // Eðer tetikleyen obje "Player" tagine sahipse
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowObjectTemporarily());
        }
    }

    private IEnumerator ShowObjectTemporarily()
    {
        if (objectToShow != null)
        {
            // Obje görünür hale gelir
            objectToShow.SetActive(true);

            // Yarým saniye bekle
            yield return new WaitForSeconds(0.5f);

            // Obje tekrar gizlenir
            objectToShow.SetActive(false);
        }
    }
}
