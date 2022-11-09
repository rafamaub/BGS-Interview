using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipsScreen : MonoBehaviour
{
    [SerializeField] private EquippableSlot head;
    [SerializeField] private EquippableSlot body;
    [SerializeField] private EquippableSlot boots;
    [SerializeField] private EquippableSlot weapon;

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


}
