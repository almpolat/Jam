using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gerçeğegeçiş : MonoBehaviour
{
    private bool playerInTrigger = false;
    public GameObject wake;
    public GameObject tablo1;
    public GameObject tablo2;
    public GameObject tablo3;
    public GameObject tablo4;
    public GameObject tablo5;

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
       if(tablo1.activeInHierarchy&& tablo2.activeInHierarchy && tablo3.activeInHierarchy && tablo4.activeInHierarchy && tablo5.activeInHierarchy)
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // Yeni sahneye geç
            SceneManager.LoadScene("EvIkıncırüyafter");
        }
    }
}