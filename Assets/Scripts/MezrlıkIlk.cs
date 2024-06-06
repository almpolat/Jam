using UnityEngine;

public class MezrlıkIlk : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject masadakiFener;

    [SerializeField] private GameObject dumanTrigger;
    void Start()
    {
        Dialog.Instance.LoadAndStartDialog("mezarlıkIlk");

    }

    // Update is called once per frame
    void Update()
    {
        checkFener();
        checkDuman();
    }

    void checkFener()
    {
        if (masadakiFener != null && !masadakiFener.activeInHierarchy)
        {
            Dialog.Instance.LoadAndStartDialog("mezarlikFenerAAldıktanSonra");
            masadakiFener = null;
        }
    }


    void checkDuman()
    {
        if (PlayerTriggers.Instance.isDumanSeen)
        {
            Dialog.Instance.LoadAndStartDialog("Duman");
            //dumanTrigger = null;
            dumanTrigger.SetActive(false);
            PlayerTriggers.Instance.isDumanSeen = false;
        }
    }
}
