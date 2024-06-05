using UnityEngine;
using UnityEngine.SceneManagement;

public class RuyaIlkManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dialog.Instance.LoadAndStartDialog("ruyaSiyah");
    }

    private void Update()
    {
        if (Dialog.Instance.IsDialogFinished)
        {
            SceneManager.LoadScene("EvIlk");
        }
    }

}
