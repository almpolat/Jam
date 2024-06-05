using UnityEngine;

public class rüyayageçiş : MonoBehaviour
{
    private bool playerInTrigger = false;
    [SerializeField] GameObject sleepInteract;
    [SerializeField] GameObject ruyaCanvas;

    // Bu fonksiyon tetikleme alanına bir obje girdiğinde çağrılır
    private void OnTriggerEnter(Collider other)
    {
        // Eğer tetikleyen obje "Player" tagine sahipse
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            sleepInteract.SetActive(true);

        }
    }

    // Bu fonksiyon tetikleme alanından bir obje çıktığında çağrılır
    private void OnTriggerExit(Collider other)
    {
        // Eğer tetikleyen obje "Player" tagine sahipse
        if (other.CompareTag("Player"))
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
            Dialog.Instance.LoadAndStartDialog("ruyaSiyah");
            ruyaCanvas.SetActive(true);
        }

        if (Dialog.Instance.IsDialogFinished)
        {

            ruyaCanvas.SetActive(false);
        }
    }
}