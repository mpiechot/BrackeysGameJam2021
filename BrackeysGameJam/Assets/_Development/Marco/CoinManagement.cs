using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class CoinManagement : MonoBehaviour
{
    [SerializeField] private int coins = 40;
    private static CoinManagement manager;
    
    public UnityEvent<int> CoinsChangedEvent = new UnityEvent<int>();

    public static CoinManagement GetInstance()
    {
        return manager;
    }

    public void Awake()
    {
        manager = this;
    }

    public void OnCoinsCollected(int ammount)
    {
        coins += ammount;
        CoinsChangedEvent.Invoke(coins);
    }
    public bool OnCoinsReduced(int ammount)
    {
        if (coins - ammount < 0)
        {
            return false;
        }
        coins -= ammount;
        CoinsChangedEvent.Invoke(coins);
        return true;
    }

    public int GetCoins()
    {
        return coins;
    }
}
