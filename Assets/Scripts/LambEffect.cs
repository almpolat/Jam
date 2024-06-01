using System.Collections;
using UnityEngine;

public class LambEffect : MonoBehaviour
{
    public GameObject lamb;
    public GameObject lambSpot;

    private void Start()
    {
        StartCoroutine(yanýpSon());
    }
    IEnumerator yanýpSon()
    {
        while (true)
        {


            lamb.SetActive(false);
            lambSpot.SetActive(false);

            yield return new WaitForSeconds(1);

            lamb.SetActive(true);
            lambSpot.SetActive(true);

            yield return new WaitForSeconds(1);
        }




    }

}
