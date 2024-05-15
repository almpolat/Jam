using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Evsahnesibitişi: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Çalş");
        if (other.CompareTag("Player"))
        {
            // Sahne 1'i yükler
            SceneManager.LoadScene(1);
        }
    }
}
