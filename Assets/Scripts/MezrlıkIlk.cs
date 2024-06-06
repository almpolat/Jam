using UnityEngine;

public class MezrlıkIlk : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject masadakiFener;
    void Start()
    {
        Dialog.Instance.LoadAndStartDialog("mezarlıkIlk");

    }

    // Update is called once per frame
    void Update()
    {
        checkFener();
    }

    void checkFener()
    {
        if (masadakiFener != null && !masadakiFener.activeInHierarchy)
        {
            Dialog.Instance.LoadAndStartDialog("mezarlikFenerAAldıktanSonra");
            masadakiFener = null;
        }
    }
}
