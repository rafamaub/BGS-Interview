using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem actualItem;
    public int amountOfItens;

    [Header("UI")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemAmount;
    [SerializeField] private SelectionBorder selectionTip;


    InventoryManager manager;
    public bool IsEmpty { get { return actualItem == null; } }

    public void InitializeSlot(InventoryManager man)
    {
        manager = man;
    }
    public void ReceiveItem(InventoryItem newItem)
    {
        
        if (actualItem && actualItem.isStackable)
        {
            amountOfItens++;
        }
        else if(!actualItem)
        {
            GetComponent<Button>().enabled = true;
            actualItem = newItem;
            amountOfItens = 1;

            itemIcon.sprite = actualItem.itemIcon;
            itemIcon.enabled = true;
        }

        
        if (amountOfItens > 1)
        {
            itemAmount.text = amountOfItens.ToString();
        }
        else
        {
            itemAmount.text = "";
        }
        selectionTip.gameObject.SetActive(true);
    }


    public void DiscardItem()
    {
        amountOfItens--;
        if (amountOfItens > 1)
        {
            itemAmount.text = amountOfItens.ToString();
        }
        else
        {
            itemAmount.text = "";
        }

        if (amountOfItens <= 0)
        {
            
            manager.RemoveSlotFromInventory(this);
            
        }
    }

    public void SelectMe()
    {
        //TurnOn Effects
        //Tell manager that you are selected
        selectionTip.Clicked();
        manager.SelectSlot(this);

    }

    public void UnselectMe()
    {
        selectionTip.Unselect();
        //TurnOff Effects
    }
}
