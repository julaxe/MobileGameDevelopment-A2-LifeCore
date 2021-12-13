using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusSingleton : MonoBehaviour
{
    public static GameStatusSingleton Instance;
    public int score = 0;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
            Instance = this;
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }
}
