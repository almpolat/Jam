using UnityEngine;

public class masalambası : MonoBehaviour
{
    private bool isEPressed = false;

    void Update()
    {
        // "E" tuşuna basıldığında isEPressed değerini true yap
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // "Player" tag'ına sahip obje bu nesneye temas ettiğinde ve "E" tuşuna basıldığında
        if (other.CompareTag("Player") && isEPressed)
        {
            // masalamba tagına sahip objeyi bul
            GameObject masalamba = GameObject.FindGameObjectWithTag("masalamba");


            LanternLight.Instance.isLanternActive = true;


            // masalamba objesi varsa ve aktifse, inaktif hale getir
            if (masalamba != null && masalamba.activeSelf)
            {
                masalamba.SetActive(false);
            }
            // isEPressed'i false yap, böylece bir sonraki basışa hazır hale getir
            isEPressed = false;
        }
    }
}
