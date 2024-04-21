using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI bile�enlerine eri�im sa�lamak i�in

public class ImageVisibilityTimer : MonoBehaviour
{
    //public GameObject pnl1;
    // Gizlenecek Image nesnesine referans
    public GameObject imageComponent;

    // Tetikleyici bir nesne ile etkile�ime girdi�inde �a�r�l�r
    private void OnTriggerEnter(Collider other)
    {
        // Image'� aktif hale getir
        imageComponent.SetActive(true);
        //pnl1.SetActive(true);

        // Belirli bir s�re sonra Image'� tekrar gizle
        StartCoroutine(HideImageAfterTime(0.6f)); // 0.2 saniye sonra gizle
    }

    // Oyun ba�lad���nda Image'� pasif hale getir
    private void Start()
    {
        // Image'� pasif hale getir
        imageComponent.SetActive(false);
    }

    // Belirli bir s�re sonra Image'� gizleyen Coroutine
    IEnumerator HideImageAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        imageComponent.SetActive(false);
    }
}