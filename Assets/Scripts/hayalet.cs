using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hayalet : MonoBehaviour
{
    public GameObject ghostObject; // Hayalet objesi

    private void Start()
    {
        // Baþlangýçta hayalet objesini devre dýþý býrak
        ghostObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Trigger eden objenin "Car" tag'ýna sahip olup olmadýðýný kontrol et
        if (other.CompareTag("Car"))
        {
            // Hayalet objesini etkinleþtir
            ghostObject.SetActive(true);
        }
    }
}
