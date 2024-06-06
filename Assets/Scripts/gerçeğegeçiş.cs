using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gerçeğegeçiş : MonoBehaviour
{
    private bool playerInTrigger = false;
    public GameObject wake;
    public GameObject objectToHide;

    // Bu fonksiyon tetikleme alanına bir obje girdiğinde çağrılır
    private void OnTriggerEnter(Collider other)
    {
        // Eğer tetikleyen obje "Player" tagine sahipse
        if (other.CompareTag("Player") && wake != null)
        {
            playerInTrigger = true;
            wake.SetActive(true);
        }
    }

    // Bu fonksiyon tetikleme alanından bir obje çıktığında çağrılır
    private void OnTriggerExit(Collider other)
    {
        // Eğer tetikleyen obje "Player" tagine sahipse
        if (other.CompareTag("Player") && wake != null)
        {
            playerInTrigger = false;
            wake.SetActive(false);
        }
    }

    private void Update()
    {
        // Eğer "Player" tetikleme alanında ve "E" tuşuna basıldıysa
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // objectToHide objesini gizle
            if (objectToHide != null)
            {
                objectToHide.SetActive(false);
            }

            // Yeni sahneye geç
            SceneManager.LoadScene(5);
        }
    }
}