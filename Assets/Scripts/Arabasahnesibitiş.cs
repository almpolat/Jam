using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arabasahnesibitiş : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 'other' parametresi, trigger alanına giren nesneyi temsil eder
        // Eğer bu nesnen,in etiketi 'Car' ise, sahne yüklenir
        Debug.Log("Çalş");
        if (other.CompareTag("Car"))
        {
            // Sahne 1'i yükler
            SceneManager.LoadScene(2);
        }
    }
}
