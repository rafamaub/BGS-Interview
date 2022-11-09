using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopList", menuName = "Inventory System/Shopping List")]
public class ShoppingList : ScriptableObject
{
    public OnSaleItem[] availableItems;

}

[System.Serializable]
public class OnSaleItem
{
    public InventoryItem item;
    public int overridePrice;
    public int quantityAvailable;
}

