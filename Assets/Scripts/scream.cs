using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scream : MonoBehaviour
{
    // AudioSource bileþenine referans
    public AudioSource audioSource;

    // Tetikleyici bir nesne ile etkileþime girdiðinde çaðrýlýr
    private void OnTriggerEnter(Collider other)
    {
        // Burada, tetikleyiciye giren nesnenin adý veya etiketi kontrol edilebilir
        // Örneðin: if(other.CompareTag("Player"))
        // Bu örnekte, herhangi bir nesne tetikleyiciye girdiðinde ses çalýnacak

        // AudioSource bileþenini baþlat
        audioSource.Play();
    }
}
