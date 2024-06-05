using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tablo : MonoBehaviour
{
    public GameObject tmpToShow;  // Aktif olacak TMP objesi
    public GameObject tmpToHide;  // Gizlenecek TMP objesi
    private bool playerInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (tmpToShow != null)
            {
                tmpToShow.SetActive(true); // TMP objesini aktif yap
            }
            if (tmpToHide != null)
            {
                tmpToHide.SetActive(false); // TMP objesini gizle
            }
        }
    }
}
