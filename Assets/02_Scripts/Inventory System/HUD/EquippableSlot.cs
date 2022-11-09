using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippableSlot : MonoBehaviour
{
    [SerializeField] private EquippableItem itemEquipped;

    [Header("UI")]
    [SerializeField] private Image itemIcon;

    InventoryManager manager;

    public void InitializeSlot(InventoryManager man)
    {
        manager = man;
    }

    public void EquipItem(EquippableItem newItem)
    {
        if(itemEquipped)
        {
            RemoveItem();
        }

        itemEquipped = newItem;
        itemIcon.sprite = itemEquipped.itemIcon;
        itemIcon.enabled = true;
        GetComponent<Button>().enabled = true;
        //ADD EFFECTS FROM ARMOR OR WEAPON

    }

    public void RemoveItem()
    {
        //RETURN TO INVENTORY
        itemIcon.enabled = false;
        manager.GetItem(itemEquipped);
        GetComponent<Button>().enabled = false;

        itemEquipped = null;
        //REMOVE EFFECTS FROM ARMOR OR WEAPON
    }
}
