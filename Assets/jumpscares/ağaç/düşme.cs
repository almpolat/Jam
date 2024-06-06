using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class düşme : MonoBehaviour
{
    public Animator düşmeanim;
    public AudioSource audioSource;
    void Start()
    {
        // Başlangıçta sesi kapat
        audioSource.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            düşmeanim.SetTrigger("düşme");
            // Sesi başlat
            audioSource.Play();

            // 2 saniye sonra sesi durdur
            Invoke("StopAudio", 5f);
        }
    }
    void StopAudio()
    {
        // Sesi durdur
        audioSource.Stop();
    }
}
