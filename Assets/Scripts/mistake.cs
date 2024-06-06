using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mistake : MonoBehaviour
{
    public GameObject targetObject; // Hedef nesne
    public AudioSource audioSource;
    private bool isPlaying = false;
    private bool isTriggered = false;

    void Start()
    {
        // Nesneye AudioSource bileþeni ekleyin
        audioSource.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        // Trigger'a giren nesne Player tag'ine sahip mi kontrol edin
        if (other.CompareTag("Player"))
        {
            // Eðer etkileþime girerse ve daha önce tetiklenmediyse
            if (!isTriggered)
            {
                isTriggered = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Trigger'dan çýkan nesne Player tag'ine sahip mi kontrol edin
        if (other.CompareTag("Player"))
        {
            // Eðer oyuncu trigger'dan çýkarsa, tetiklenme durumunu sýfýrlayýn
            isTriggered = false;
        }
    }

    void Update()
    {
        // Eðer oyuncu tetikleyiciye girdiyse ve E tuþuna bastýysa
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            // Eðer ses çalmýyorsa
            if (!isPlaying)
            {
                isPlaying = true;

                // Ses çal
                audioSource.Play();

                // Hedef nesneyi aktif hale getir
                if (targetObject != null)
                {
                    targetObject.SetActive(true);
                    // 3 saniye sonra hedef nesneyi inaktif hale getir
                    Invoke("DeactivateTargetObject", 3f);
                }
            }
        }
    }

    void DeactivateTargetObject()
    {
        // Hedef nesneyi inaktif hale getir
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
        isPlaying = false;
        isTriggered = false;
        // Ses durdur
        audioSource.Stop();
    }
}
