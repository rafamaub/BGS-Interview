using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Consumable")]
public class ConsumableInventoryItem : InventoryItem
{
    [Header("Consumable Stats")]
    public float hpPoints;
    public float staminaPoints;
    public float manaPoints;
}
