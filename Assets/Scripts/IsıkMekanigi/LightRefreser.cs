using UnityEngine;

public class LightRefreser : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                LanternLight.Instance.isRefreshed = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            LanternLight.Instance.isRefreshed = false;
        }
    }
}
