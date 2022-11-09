using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopScreenManager : MonoBehaviour
{

    ShoppingList actualList;


    [SerializeField] private PopUpEffect popEffect;


    bool selling;

    [Header("Buy")]
    [SerializeField] private Button buyButtonSection;
    [SerializeField] private GameObject buyArea;
    [SerializeField] private ItemInfoSection buyInfoScreen;
    List<ShopSlot> allItens = new List<ShopSlot>();
    [SerializeField] private TextMeshProUGUI buyPriceTag;

    [Header("Sell")]
    [SerializeField] private Button sellButtonSection;
    [SerializeField] private GameObject sellArea;
    [SerializeField] private ItemInfoSection sellInfoScreen;
    List<ShopSlot> inventoryItens = new List<ShopSlot>();
    [SerializeField] private TextMeshProUGUI sellPriceTag;

    [Header("UI Objects")]
    [SerializeField] private ShopSlot slotPrefab;
    [SerializeField] private Transform buyGridParent;
    [SerializeField] private Transform sellGridParent;

    [SerializeField] private Button buyButton;

    ShopSlot selectedSlot;
    InventoryManager invManager;
    private void Awake()
    {
        buyInfoScreen.InitializeInfoScreenShop(this);
        sellInfoScreen.InitializeInfoScreenShop(this);

        invManager = FindObjectOfType<InventoryManager>();
    }
    public void OpenScreen()
    {
        popEffect.Pop();
    }

    public void CloseScreen()
    {
        popEffect.Unpop();
    }

    public void InitializeStore(ShoppingList list)
    {
        if(actualList && allItens.Count > 0)
        {
            foreach(ShopSlot slot in allItens)
            {
                Destroy(slot.gameObject);
            }

            allItens.Clear();
        }


        actualList = list;

        foreach(OnSaleItem saleItem in actualList.availableItems)
        {
            ShopSlot shopSlot = Instantiate(slotPrefab, buyGridParent);
            shopSlot.InitializeSlot(saleItem, this);
            allItens.Add(shopSlot);
        }
        SwitchToBuy();
        OpenScreen();
    }

    public void SwitchToBuy()
    {
        selling = false;
        sellInfoScreen.HideScreen();

        buyButtonSection.interactable = false;
        sellButtonSection.interactable = true;

        buyArea.SetActive(true);
        sellArea.SetActive(false);
    }
    public void SwitchToSell()
    {
        selling = true;
        buyInfoScreen.HideScreen();

        buyButtonSection.interactable = true;
        sellButtonSection.interactable = false;

        buyArea.SetActive(false);
        sellArea.SetActive(true);

        //UPDATE INVENTORY
        if (inventoryItens.Count > 0)
        {
            foreach (ShopSlot slot in inventoryItens)
            {
                Destroy(slot.gameObject);
            }

            inventoryItens.Clear();
        }

        foreach (OnSaleItem invItem in invManager.ReturnAllItens())
        {
            ShopSlot shopSlot = Instantiate(slotPrefab, sellGridParent);
            shopSlot.InitializeSlot(invItem, this);
            inventoryItens.Add(shopSlot);
        }
    }
    public void BuyItem()
    {
        CoinManager.Singleton.ChangeMoney(-selectedSlot.actualItem.overridePrice);
        //GIVE ITEM
        invManager.GetItem(selectedSlot.actualItem.item);
        buyInfoScreen.HideScreen();
    }
    public void SellItem()
    {
        CoinManager.Singleton.ChangeMoney(selectedSlot.actualItem.overridePrice);
        invManager.TotalDiscardItem(selectedSlot.actualItem.item);
        sellInfoScreen.HideScreen();
        SwitchToSell();

    }

    public void SelectSlot(ShopSlot newSlot)
    {
        if(selectedSlot)
        {
            selectedSlot.UnselectMe();
        }

        selectedSlot = newSlot;

        

        if(selling)
        {
            sellPriceTag.text = newSlot.actualItem.overridePrice.ToString();
            buyButton.interactable = true;
            sellInfoScreen.ShowItemInfo(newSlot.actualItem.item);
        }
        else
        {
            buyPriceTag.text = newSlot.actualItem.overridePrice.ToString();
            buyInfoScreen.ShowItemInfo(newSlot.actualItem.item);
            if (!CoinManager.Singleton.HasMoney(selectedSlot.actualItem.overridePrice))
            {
                buyButton.interactable = false;
            }
            else
            {
                buyButton.interactable = true;
            }
        }


        
    }
}
