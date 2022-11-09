using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipsScreen : MonoBehaviour
{
    [SerializeField] private EquippableSlot head;
    [SerializeField] private EquippableSlot body;
    [SerializeField] private EquippableSlot boots;
    [SerializeField] private EquippableSlot weapon;

    public List<EquippableSlot> allSlots = new List<EquippableSlot>();

    private void Awake()
    {
        allSlots.Add(head);
        allSlots.Add(body);
        allSlots.Add(boots);
        allSlots.Add(weapon);
    }
    public void InitializeEquipScreen(InventoryManager man)
    {
        head.InitializeSlot(man);
        body.InitializeSlot(man);
        boots.InitializeSlot(man);
        weapon.InitializeSlot(man);
    }

    public void EquipItem(EquippableItem item)
    {
        switch (item.myType)
        {
            case ItemType.Boots:
                boots.EquipItem(item);
                break;
            case ItemType.ChestArmor:
                body.EquipItem(item);
                break;
            case ItemType.Helmet:
                head.EquipItem(item);
                break;
            case ItemType.Weapon:
                weapon.EquipItem(item);
                break;

        }

    }

    public EquippableSlot FindSlotWithItem(InventoryItem item)
    {
        if(head.itemEquipped == item)
        {
            return head;
        }
        if (body.itemEquipped == item)
        {
            return body;
        }
        if (boots.itemEquipped == item)
        {
            return boots;
        }
        if (weapon.itemEquipped == item)
        {
            return weapon;
        }

        return null;
    }

}
