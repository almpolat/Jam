using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hayalet : MonoBehaviour
{
    public GameObject ghostObject; // Hayalet objesi

    private void Start()
    {
        // Ba�lang��ta hayalet objesini devre d��� b�rak
        ghostObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Trigger eden objenin "Car" tag'�na sahip olup olmad���n� kontrol et
        if (other.CompareTag("Car"))
        {
            // Hayalet objesini etkinle�tir
            ghostObject.SetActive(true);
        }
    }
}
