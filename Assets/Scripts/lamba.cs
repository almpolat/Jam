using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamba : MonoBehaviour
{
    private GameObject[] ellambaObjects; // Ellamba tag'�na sahip objeleri depolamak i�in dizi
    private bool isEPressed = false;

    void Start()
    {
        // "ellamba" tag'�na sahip t�m objeleri bul ve ba�lang��ta inaktif yap
        ellambaObjects = GameObject.FindGameObjectsWithTag("ellamba");
        foreach (GameObject obj in ellambaObjects)
        {
            obj.SetActive(false);
        }

        // E�er hi� ellamba objesi bulunamad�ysa uyar� ver
        if (ellambaObjects.Length == 0)
        {
            Debug.LogWarning("Ellamba tag'�na sahip obje bulunamad�.");
        }
    }

    void Update()
    {
        // "E" tu�una bas�l�rsa isEPressed de�erini true yap
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // "Player" tag'�na sahip obje bu nesneye temas etti�inde
        if (other.CompareTag("Player"))
        {
            // "E" tu�una bas�ld���nda ve hi�bir ellamba etkin de�ilse i�lemleri ger�ekle�tir
            if (isEPressed && !AnyEllambaActive())
            {
                // T�m ellamba objelerini etkinle�tir
                foreach (GameObject obj in ellambaObjects)
                {
                    obj.SetActive(true);
                }

                // isEPressed'i false yap, b�ylece bir sonraki bas��a haz�r hale getir
                isEPressed = false;
            }
        }
    }

    // Herhangi bir ellamba objesinin etkin olup olmad���n� kontrol eden yard�mc� fonksiyon
    bool AnyEllambaActive()
    {
        foreach (GameObject obj in ellambaObjects)
        {
            if (obj.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}