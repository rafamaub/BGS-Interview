using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : BasicInteractable
{
    [SerializeField] private ShoppingList shopList;
    public override void Interact()
    {
        base.Interact();
        FindObjectOfType<ShopScreenManager>().InitializeStore(shopList);

    }

    public override void OffRange()
    {
        FindObjectOfType<ShopScreenManager>().CloseScreen();
        base.OffRange();
        
    }
}
