using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mezarlıkikigidiş : MonoBehaviour
{
    // Bu fonksiyon tetikleme alanına bir obje girdiğinde çağrılır
    private void OnTriggerEnter(Collider other)
    {
        // Eğer tetikleyen obje "Player" tagine sahipse
        if (other.CompareTag("Player"))
        {
            // 7. sahneyi yükle
            SceneManager.LoadScene("LoadingMezar2");
        }
    }
}