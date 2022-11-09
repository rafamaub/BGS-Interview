using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MoneyVisualizer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI coinAmountText;
    int actualMoney;

    private void Start()
    {
        actualMoney = CoinManager.Singleton.money;
        coinAmountText.text = actualMoney.ToString();
    }

    public void OnChangedMoney(int newMoney)
    {
        int diff = actualMoney - newMoney;

        actualMoney = newMoney;
        if(diff < 0)
        {
            //RECEIVED MONEY

            //PLAY GREEN COLOR EFFECT
            ChangeTextColor(Color.green);
            //PLAY RECEIVE SOUND
        }
        else
        {
            //LOST MONEY

            //PLAY RED COLOR EFFECT
            ChangeTextColor(Color.red);
            //PLAY LOST SOUND
        }

        coinAmountText.text = actualMoney.ToString();
    }


    void ChangeTextColor(Color newColor)
    {
        coinAmountText.DOComplete();

        Color cacheColor = coinAmountText.color;

        coinAmountText.DOColor(newColor, 0.15f).OnComplete( () => 
        {
            coinAmountText.DOColor(cacheColor, 0.15f);
        });
    }
}
