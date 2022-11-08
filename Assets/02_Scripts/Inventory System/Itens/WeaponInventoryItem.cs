using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Weapon")]
public class WeaponInventoryItem : EquippableItem
{
    [Header("Weapon Stats")]
    public float damage;
    public float durability;
}
