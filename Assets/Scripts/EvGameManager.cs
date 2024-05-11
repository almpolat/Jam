using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EvGameManager : MonoBehaviour
{
    public event Action onSleep;

    public static EvGameManager Instance;

    private void Awake()
    {
        Instance = this;
    }


}
