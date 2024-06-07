using UnityEngine;

public class jumpsScareRun : MonoBehaviour
{
    [SerializeField] GameObject monsnterRun;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monsnterRun.SetActive(true);

        }
    }
}
