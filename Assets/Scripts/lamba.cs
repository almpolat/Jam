using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamba : MonoBehaviour
{
    private GameObject[] ellambaObjects; // Ellamba tag'ýna sahip objeleri depolamak için dizi
    private bool isEPressed = false;

    void Start()
    {
        // "ellamba" tag'ýna sahip tüm objeleri bul ve baþlangýçta inaktif yap
        ellambaObjects = GameObject.FindGameObjectsWithTag("ellamba");
        foreach (GameObject obj in ellambaObjects)
        {
            obj.SetActive(false);
        }

        // Eðer hiç ellamba objesi bulunamadýysa uyarý ver
        if (ellambaObjects.Length == 0)
        {
            Debug.LogWarning("Ellamba tag'ýna sahip obje bulunamadý.");
        }
    }

    void Update()
    {
        // "E" tuþuna basýlýrsa isEPressed deðerini true yap
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // "Player" tag'ýna sahip obje bu nesneye temas ettiðinde
        if (other.CompareTag("Player"))
        {
            // "E" tuþuna basýldýðýnda ve hiçbir ellamba etkin deðilse iþlemleri gerçekleþtir
            if (isEPressed && !AnyEllambaActive())
            {
                // Tüm ellamba objelerini etkinleþtir
                foreach (GameObject obj in ellambaObjects)
                {
                    obj.SetActive(true);
                }

                // isEPressed'i false yap, böylece bir sonraki basýþa hazýr hale getir
                isEPressed = false;
            }
        }
    }

    // Herhangi bir ellamba objesinin etkin olup olmadýðýný kontrol eden yardýmcý fonksiyon
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