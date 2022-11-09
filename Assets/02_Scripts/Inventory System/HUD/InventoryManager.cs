using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private int slotAmount = 20;

    [SerializeField] private PopUpEffect popUpEffect;

    private List<InventorySlot> allSlots = new List<InventorySlot>();
    // Start is called before the first frame update
    void Start()
    {
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


    void AddSlotToInventory()
    {
        InventorySlot slot = Instantiate(slotPrefab, slotParent);
        allSlots.Add(slot);
    }

    void RemoveSlotFromInventory(InventorySlot toRemove)
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
            if(slot.IsEmpty || slot.actualItem == item)
            {
                slot.ReceiveItem(item);
                return;
            }

        }
    }
}
