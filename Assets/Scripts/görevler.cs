using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class görevler : MonoBehaviour
{
    // Referanslar
    public GameObject görevObjesi;
    public GameObject gül;

    private void Start()
    {
        // Oyun başladığında görev objesini inaktif hale getir
        if (görevObjesi != null)
        {
            görevObjesi.SetActive(false);
        }
        if (gül != null)
        {
            gül.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // Trigger'ı tetikleyen obje "Player" tag'ine sahip ise
        if (other.CompareTag("Player"))
        {
            // Görev objesini aktif hale getir
            if (görevObjesi != null)
            {
                görevObjesi.SetActive(true);
            }
            if (gül != null)
            {
                gül.SetActive(true);
            }
        }
    }
}
