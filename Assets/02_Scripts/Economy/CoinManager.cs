using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Singleton;

    public int money = 500;
    [SerializeField] private MainEvent moneyChanged;
    void Awake()
    {
        if(!Singleton)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public bool HasMoney(int amountToCompare)
    {
        if(money >= amountToCompare)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ChangeMoney(int amount)
    {
        money += amount;

        moneyChanged.Occured(money);
    }
}
