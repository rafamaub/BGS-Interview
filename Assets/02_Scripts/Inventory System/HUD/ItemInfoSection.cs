using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ItemInfoSection : MonoBehaviour
{
    const float originalXPos = -165f;
    const float targetXPos = 100f;
    [SerializeField] private bool isShop;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private Image itemIcon;

    [SerializeField] private Button equipButton;
    [SerializeField] private Button consumeButton;

    InventoryItem showingItem;
    InventoryManager manager;
    ShopScreenManager shopManager;
    RectTransform myRect;

    public void InitializeInfoScreen(InventoryManager man)
    {
        myRect = GetComponent<RectTransform>();
        manager = man;
    }
    public void InitializeInfoScreenShop(ShopScreenManager man)
    {
        myRect = GetComponent<RectTransform>();
        shopManager = man;
    }

    public void HideScreen()
    {
        if(isShop)
        {
            myRect.DOComplete();
            myRect.DOAnchorPosX(originalXPos, 0.25f);
        }
        else if(!manager.GetSlotFromItem(showingItem))
        {
            myRect.DOComplete();
            myRect.DOAnchorPosX(originalXPos, 0.25f);
        }
    }

    public void ShowItemInfo(InventoryItem item)
    {
        myRect.DOComplete();
        myRect.DOAnchorPosX(originalXPos, 0);
        myRect.DOAnchorPosX(targetXPos, 0.1f);

        showingItem = item;
        itemName.text = showingItem.itemName;
        itemDescription.text = showingItem.itemDescrption;
        itemIcon.sprite = showingItem.itemIcon;


        if (showingItem.myType == ItemType.Consumable)
        {
            consumeButton.gameObject.SetActive(true);
        }
        else
        {
            consumeButton.gameObject.SetActive(false);
        }

        if (showingItem.myType == ItemType.ChestArmor || showingItem.myType == ItemType.Boots || showingItem.myType == ItemType.Helmet || showingItem.myType == ItemType.Arms)
        {
            equipButton.gameObject.SetActive(true);
        }
        else
        {
            equipButton.gameObject.SetActive(false);
        }

        if (isShop)
        {
            consumeButton.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(false);
        }
    }

    public void DiscardItem()
    {
        manager.GetSlotFromItem(showingItem).DiscardItem();
        HideScreen();
    }

    public void ResolveItem()
    {
        
        if (showingItem.myType == ItemType.Consumable)
        {
            //consItem.Resolve();
            DiscardItem();
        }
        else if(showingItem.myType == ItemType.ChestArmor || showingItem.myType == ItemType.Boots || showingItem.myType == ItemType.Helmet || showingItem.myType == ItemType.Arms)
        {
            DiscardItem();
            manager.EquipItem((EquippableItem)showingItem);
            
        }

        HideScreen();
    }

}
