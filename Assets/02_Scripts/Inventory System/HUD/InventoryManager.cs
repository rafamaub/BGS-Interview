using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private int slotAmount = 20;

    [SerializeField] private PopUpEffect popUpEffect;
    [SerializeField] private ItemInfoSection infoSection;
    [SerializeField] private CharacterEquipsScreen equipsScreen;

    private List<InventorySlot> allSlots = new List<InventorySlot>();

    InventorySlot slotSelected;
    // Start is called before the first frame update
    void Start()
    {
        infoSection.InitializeInfoScreen(this);
        equipsScreen.InitializeEquipScreen(this);
        if(allSlots.Count == 0)
        {
            for(int i = 0; i < slotAmount; i++)
            {
                AddSlotToInventory();
            }
        }
    }

    public void ShowInventory()
    {
        popUpEffect.DynamicPop();
    }

    public void EquipItem(EquippableItem item)
    {
        equipsScreen.EquipItem(item);
    }
    void AddSlotToInventory()
    {
        InventorySlot slot = Instantiate(slotPrefab, slotParent);
        slot.InitializeSlot(this);
        allSlots.Add(slot);
    }

    public void RemoveSlotFromInventory(InventorySlot toRemove)
    {
        allSlots.Remove(toRemove);
        Destroy(toRemove.gameObject);
        AddSlotToInventory();
        //remove when discard item completely
    }

    public void GetItem(InventoryItem item)
    {
        foreach(InventorySlot slot in allSlots)
        {
            if(slot.IsEmpty || (slot.actualItem == item && item.isStackable))
            {
                slot.ReceiveItem(item);
                return;
            }

        }
    }

    public void SelectSlot(InventorySlot slot)
    {
        if(slotSelected)
        {
            slotSelected.UnselectMe();
        }

        slotSelected = slot;

        infoSection.ShowItemInfo(slot.actualItem);
    }

    public InventorySlot GetSlotFromItem(InventoryItem itemToCheck)
    {
        foreach(InventorySlot slot in allSlots)
        {
            if(slot.actualItem == itemToCheck)
            {
                return slot;
            }
        }

        return null;
    }

    public void TotalDiscardItem(InventoryItem toDiscard) //THIS FUNCTION IS TO DISCARD ONE BY ONE ITEM ON INVENTORY OR AN EQUIPPED ITEM LIKE ARMOR
    {
        foreach (InventorySlot slot in allSlots)
        {
            if (slot.actualItem == toDiscard)
            {
                slot.DiscardItem();
                return;
            }

        }

        EquippableSlot equipSlot = equipsScreen.FindSlotWithItem(toDiscard);
        if(equipSlot)
        {
            equipSlot.DiscardItem();
        }

    }

    public List<OnSaleItem> ReturnAllItens()
    {
        List<OnSaleItem> allItens = new List<OnSaleItem>();

        foreach(InventorySlot slot in allSlots)
        {
            if(slot.actualItem)
            {
                allItens.Add(new OnSaleItem(slot.actualItem, slot.amountOfItens));
            }
            else
            {
                break;
            }
        }

        foreach(EquippableSlot slots in equipsScreen.allSlots)
        {
            if(slots.itemEquipped)
            {
                allItens.Add(new OnSaleItem(slots.itemEquipped, 1));
            }
        }

        return allItens;
    }
}
