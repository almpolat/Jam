using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scream : MonoBehaviour
{
    // AudioSource bile�enine referans
    public AudioSource audioSource;

    // Tetikleyici bir nesne ile etkile�ime girdi�inde �a�r�l�r
    private void OnTriggerEnter(Collider other)
    {
        // Burada, tetikleyiciye giren nesnenin ad� veya etiketi kontrol edilebilir
        // �rne�in: if(other.CompareTag("Player"))
        // Bu �rnekte, herhangi bir nesne tetikleyiciye girdi�inde ses �al�nacak

        // AudioSource bile�enini ba�lat
        audioSource.Play();
    }
}
