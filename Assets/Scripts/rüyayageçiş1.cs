using UnityEngine;
using UnityEngine.SceneManagement;


public class rüyayageçiş2 : MonoBehaviour
{
    private bool playerInTrigger = false;
    [SerializeField] GameObject sleepInteract;


    // Bu fonksiyon tetikleme alanına bir obje girdiğinde çağrılır
    private void OnTriggerEnter(Collider other)
    {
        // Eğer tetikleyen obje "Player" tagine sahipse
        if (other.CompareTag("Player") && sleepInteract != null)
        {
            playerInTrigger = true;
            sleepInteract.SetActive(true);

        }
    }

    // Bu fonksiyon tetikleme alanından bir obje çıktığında çağrılır
    private void OnTriggerExit(Collider other)
    {
        // Eğer tetikleyen obje "Player" tagine sahipse
        if (other.CompareTag("Player") && sleepInteract != null)
        {
            playerInTrigger = false;
            sleepInteract.SetActive(false);
        }
    }

    private void Update()
    {
        // Eğer "Player" tetikleme alanında ve "E" tuşuna basıldıysa
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Dialog.Instance.LoadAndStartDialog("ruyaTablo");
            SceneManager.LoadScene("RuyaTablo");

        }

    }
}