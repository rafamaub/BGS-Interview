using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Basic Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    
    [TextArea]
    public string itemDescrption;
    public Sprite itemIcon; //LUCKILY THE ICON WILL BE THE SAME AS THE PICKABLE SPRITE
    public ItemType myType;
    public bool isStackable;
    

}

public enum ItemType
{
    Undefined, Consumable, ChestArmor, Helmet, Boots, Weapon
}

[System.Serializable]
public class DirectionalSprites
{
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
}


