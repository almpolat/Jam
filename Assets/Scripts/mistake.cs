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
        // Nesneye AudioSource bile�eni ekleyin
        audioSource.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        // Trigger'a giren nesne Player tag'ine sahip mi kontrol edin
        if (other.CompareTag("Player"))
        {
            // E�er etkile�ime girerse ve daha �nce tetiklenmediyse
            if (!isTriggered)
            {
                isTriggered = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Trigger'dan ��kan nesne Player tag'ine sahip mi kontrol edin
        if (other.CompareTag("Player"))
        {
            // E�er oyuncu trigger'dan ��karsa, tetiklenme durumunu s�f�rlay�n
            isTriggered = false;
        }
    }

    void Update()
    {
        // E�er oyuncu tetikleyiciye girdiyse ve E tu�una bast�ysa
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            // E�er ses �alm�yorsa
            if (!isPlaying)
            {
                isPlaying = true;

                // Ses �al
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
