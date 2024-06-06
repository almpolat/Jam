using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hayaletanim : MonoBehaviour
{
    public Animator hayaletanime;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hayaletanime.SetTrigger("hayalet");

        }
    }
}
