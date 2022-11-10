using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clothes", menuName = "Equipment/Clothing")]
public class ScriptableEquipment : ScriptableObject
{
    public ClothingFragment[] clothingPack = null;
}

[System.Serializable]
public class ClothingFragment
{
    public Sprite sprite = null;
    public string category = "";
    public string entry = "";
}


