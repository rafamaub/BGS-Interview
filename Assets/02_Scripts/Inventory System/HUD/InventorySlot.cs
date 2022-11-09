using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem actualItem;
    [SerializeField] private int amountOfItens;

    [Header("UI")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemAmount;

    public bool IsEmpty { get { return actualItem == null; } }
    public void ReceiveItem(InventoryItem newItem)
    {
        if(actualItem && actualItem.isStackable)
        {
            amountOfItens++;
        }
        else if(!actualItem)
        {
            actualItem = newItem;
            amountOfItens = 1;

            itemIcon.sprite = actualItem.itemIcon;
            itemIcon.enabled = true;
        }

        if(amountOfItens > 1)
        {
            itemAmount.text = amountOfItens.ToString();
        }
    }


    public void DiscardItem()
    {

    }
}
