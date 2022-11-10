using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class EquipManager : MonoBehaviour
{
    [SerializeField] private SpriteLibrary m_SpriteLibraryTarget;


    [SerializeField] private ScriptableEquipment headEquip;
    [SerializeField] private ScriptableEquipment chestEquip;
    [SerializeField] private ScriptableEquipment armEquip;
    [SerializeField] private ScriptableEquipment bootsEquip;
    public void AddClothes(ScriptableEquipment newEquipment, ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Arms:
                if(armEquip)
                {
                    RemoveClothes(armEquip);
                }
                armEquip = newEquipment;
                break;
            case ItemType.ChestArmor:
                if (chestEquip)
                {
                    RemoveClothes(chestEquip);
                }
                chestEquip = newEquipment;
                break;
            case ItemType.Boots:
                if (bootsEquip)
                {
                    RemoveClothes(bootsEquip);
                }
                bootsEquip = newEquipment;
                break;
            case ItemType.Helmet:
                if (headEquip)
                {
                    RemoveClothes(headEquip);
                }
                headEquip = newEquipment;
                break;
        }

        foreach (var entry in newEquipment.clothingPack)
        {
            m_SpriteLibraryTarget.AddOverride(entry.sprite, entry.category, entry.entry);
        }

    }
    public void RemoveClothes(ScriptableEquipment oldEquipment)
    {
        foreach (var entry in oldEquipment.clothingPack)
        {
            m_SpriteLibraryTarget.RemoveOverride(entry.category, entry.entry);
        }
    }
}
