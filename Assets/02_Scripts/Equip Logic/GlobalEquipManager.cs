using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EQUIP MANAGER CONTROLS ONE DIRECTION
//GLOBAL EQUIP MANAGER CONTROL ALL DIRECTIONS
public class GlobalEquipManager : MonoBehaviour
{
    public EquipManager downEquips; //FACING DOWN DIRECTION
    public EquipManager upEquips; //FACING UP DIRECTION
    public EquipManager leftEquips; //LEFT AND RIGHT DIRECTION
    public EquipManager rightEquips; //LEFT AND RIGHT DIRECTION
    public void EquipItem(EquippableItem newItem)
    {
        if(newItem.downSpritePack)
        {
            downEquips.AddClothes(newItem.downSpritePack, newItem.myType);
        }
        if (newItem.upSpritePack)
        {
            upEquips.AddClothes(newItem.upSpritePack, newItem.myType);
        }
        if (newItem.sideSpritePack)
        {
            leftEquips.AddClothes(newItem.sideSpritePack, newItem.myType);
            rightEquips.AddClothes(newItem.sideSpritePack, newItem.myType);
        }
    }

    public void RemoveItem(EquippableItem oldItem)
    {
        if (oldItem.downSpritePack)
        {
            downEquips.RemoveClothes(oldItem.downSpritePack);
        }
        if (oldItem.upSpritePack)
        {
            upEquips.RemoveClothes(oldItem.upSpritePack);
        }
        if (oldItem.sideSpritePack)
        {
            leftEquips.RemoveClothes(oldItem.sideSpritePack);
            rightEquips.RemoveClothes(oldItem.sideSpritePack);
        }
    }
}
