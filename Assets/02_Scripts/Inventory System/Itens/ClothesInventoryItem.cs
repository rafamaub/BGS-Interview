using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Clothes")]
public class ClothesInventoryItem : EquippableItem
{
    [Header("Armor Stats")]
    public float protectionAgainstPhysicalDamage;
    public float protectionAgainstElementalDamage;
    public float durability;
}
