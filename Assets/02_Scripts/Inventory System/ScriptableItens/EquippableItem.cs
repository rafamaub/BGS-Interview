using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippableItem : InventoryItem
{
    [Header("Equip Settings")] //SPRITE PACK FOR EVERY DIRECTION THE PLAYER CAN MOVE
    public ScriptableEquipment sideSpritePack;
    public ScriptableEquipment upSpritePack;
    public ScriptableEquipment downSpritePack;
}
