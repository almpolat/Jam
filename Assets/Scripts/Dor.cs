using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dor : MonoBehaviour
{
    public Animator dooranim;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dooranim.SetTrigger("open");
        }
    }
}