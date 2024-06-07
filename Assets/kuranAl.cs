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
        // "E" tuþuna basýldýðýnda isEPressed deðerini true yap
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // "Player" tag'ýna sahip obje bu nesneye temas ettiðinde ve "E" tuþuna basýldýðýnda
        if (other.CompareTag("Player") && isEPressed)
        {
            // masalamba tagýna sahip objeyi bul
            GameObject kuranMasa = GameObject.FindGameObjectWithTag("kuranMasa");



            kuranel.SetActive(true);

            // masalamba objesi varsa ve aktifse, inaktif hale getir
            if (kuranMasa != null && kuranMasa.activeSelf)
            {
                kuranMasa.SetActive(false);
            }



            // isEPressed'i false yap, böylece bir sonraki basýþa hazýr hale getir
            isEPressed = false;
        }
    }
}
