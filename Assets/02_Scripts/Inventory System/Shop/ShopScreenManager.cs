using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopScreenManager : MonoBehaviour
{

    ShoppingList actualList;
    List<ShopSlot> allItens = new List<ShopSlot>();

    [SerializeField] private PopUpEffect popEffect;
    [SerializeField] private ItemInfoSection infoScreen;

    [Header("UI Objects")]
    [SerializeField] private ShopSlot slotPrefab;
    [SerializeField] private Transform gridParent;
    [SerializeField] private TextMeshProUGUI priceTag;
    [SerializeField] private Button buyButton;

    ShopSlot selectedSlot;
    InventoryManager invManager;
    private void Awake()
    {
        infoScreen.InitializeInfoScreenShop(this);
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
            ShopSlot shopSlot = Instantiate(slotPrefab, gridParent);
            shopSlot.InitializeSlot(saleItem, this);
            allItens.Add(shopSlot);
        }

        OpenScreen();
    }

    public void BuyItem()
    {
        CoinManager.Singleton.ChangeMoney(-selectedSlot.actualItem.overridePrice);
        //GIVE ITEM
        invManager.GetItem(selectedSlot.actualItem.item);
        infoScreen.HideScreen();
    }
    public void SelectSlot(ShopSlot newSlot)
    {
        if(selectedSlot)
        {
            selectedSlot.UnselectMe();
        }

        selectedSlot = newSlot;
        priceTag.text = newSlot.actualItem.overridePrice.ToString();
        infoScreen.ShowItemInfo(newSlot.actualItem.item);

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
