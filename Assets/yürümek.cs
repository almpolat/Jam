using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yürümek : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from this GameObject.");
        }
        else
        {
            audioSource.enabled = false; // Başlangıçta AudioSource'u devre dışı bırak
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (!audioSource.enabled)
            {
                audioSource.enabled = true;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.enabled)
            {
                audioSource.Stop();
                audioSource.enabled = false;
            }
        }
    }
}