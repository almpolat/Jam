using UnityEngine;

public class kuranAl : MonoBehaviour
{
    private bool isEPressed = false;

    public GameObject kuranel;


    private void Start()
    {
        kuranel.SetActive(false);
    }
    void Update()
    {
        // "E" tu�una bas�ld���nda isEPressed de�erini true yap
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // "Player" tag'�na sahip obje bu nesneye temas etti�inde ve "E" tu�una bas�ld���nda
        if (other.CompareTag("Player") && isEPressed)
        {
            // masalamba tag�na sahip objeyi bul
            GameObject kuranMasa = GameObject.FindGameObjectWithTag("kuranMasa");



            kuranel.SetActive(true);

            // masalamba objesi varsa ve aktifse, inaktif hale getir
            if (kuranMasa != null && kuranMasa.activeSelf)
            {
                kuranMasa.SetActive(false);
            }



            // isEPressed'i false yap, b�ylece bir sonraki bas��a haz�r hale getir
            isEPressed = false;
        }
    }
}
