using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippableSlot : MonoBehaviour
{
    public EquippableItem itemEquipped;

    [Header("UI")]
    [SerializeField] private Image itemIcon;

    InventoryManager manager;
    [SerializeField] private SelectionBorder selectionTip;
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

        selectionTip.gameObject.SetActive(true);
        itemEquipped = newItem;
        FindObjectOfType<GlobalEquipManager>().EquipItem(newItem);
        itemIcon.sprite = itemEquipped.itemIcon;
        itemIcon.enabled = true;
        GetComponent<Button>().enabled = true;
        //ADD EFFECTS FROM ARMOR OR WEAPON

    }

    public void RemoveItem()
    {
        selectionTip.gameObject.SetActive(false);
        //RETURN TO INVENTORY
        itemIcon.enabled = false;
        manager.GetItem(itemEquipped);
        FindObjectOfType<GlobalEquipManager>().RemoveItem(itemEquipped);
        GetComponent<Button>().enabled = false;

        itemEquipped = null;
        //REMOVE EFFECTS FROM ARMOR OR WEAPON
    }

    public void DiscardItem()
    {
        selectionTip.gameObject.SetActive(false);
        //RETURN TO INVENTORY
        itemIcon.enabled = false;
        //manager.GetItem(itemEquipped);
        GetComponent<Button>().enabled = false;

        itemEquipped = null;
        //REMOVE EFFECTS FROM ARMOR OR WEAPON
    }
}
