using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGiver : MonoBehaviour
{
    int amountToGive = 100;
    [SerializeField] private bool onTrigger;
    [SerializeField] private bool destroyOnGive;

    public void GiveMoney()
    {
        CoinManager.Singleton.ChangeMoney(amountToGive);
        if(destroyOnGive)
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(onTrigger)
        {
            GiveMoney();
        }
    }
}
