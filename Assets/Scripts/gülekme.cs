using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject sarýGülObjesi; // Sarý gül objesini Unity Editor'den sürükleyip býrakýn

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the 'Player' tag
        if (other.CompareTag("Player"))
        {
            // Activate the sarýGülObjesi
            sarýGülObjesi.SetActive(true);
        }
    }

    private void Start()
    {
        // Deactivate the sarýGülObjesi at the beginning
        sarýGülObjesi.SetActive(false);
    }
}