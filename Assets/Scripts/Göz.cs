using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Göz : MonoBehaviour
{
    // Canvas ve animasyonları içeren GameObject'in referansı
    public GameObject eyeCanvas;
    public Animator imageAnimator;
    public Animator image1Animator;

    private void OnTriggerEnter(Collider other)
    {
        // Eğer trigger'a giren nesnenin etiketi 'Player' ise
        if (other.CompareTag("Car"))
        {
            // 'Göz' etiketine sahip Canvas'i etkinleştir
            eyeCanvas.SetActive(true);

            // 'Image' ve 'Image1' objelerinin animasyonlarını başlat
            imageAnimator.SetTrigger("close");
            image1Animator.SetTrigger("close");
        }
        if (other.CompareTag("Player"))
        {
            // 'Göz' etiketine sahip Canvas'i etkinleştir
            eyeCanvas.SetActive(true);

            // 'Image' ve 'Image1' objelerinin animasyonlarını başlat
            imageAnimator.SetTrigger("close");
            image1Animator.SetTrigger("close");
        }
    }
}
