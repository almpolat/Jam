using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI bileþenlerine eriþim saðlamak için

public class ImageVisibilityTimer : MonoBehaviour
{
    //public GameObject pnl1;
    // Gizlenecek Image nesnesine referans
    public GameObject imageComponent;

    // Tetikleyici bir nesne ile etkileþime girdiðinde çaðrýlýr
    private void OnTriggerEnter(Collider other)
    {
        // Image'ý aktif hale getir
        imageComponent.SetActive(true);
        //pnl1.SetActive(true);

        // Belirli bir süre sonra Image'ý tekrar gizle
        StartCoroutine(HideImageAfterTime(0.6f)); // 0.2 saniye sonra gizle
    }

    // Oyun baþladýðýnda Image'ý pasif hale getir
    private void Start()
    {
        // Image'ý pasif hale getir
        imageComponent.SetActive(false);
    }

    // Belirli bir süre sonra Image'ý gizleyen Coroutine
    IEnumerator HideImageAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        imageComponent.SetActive(false);
    }
}