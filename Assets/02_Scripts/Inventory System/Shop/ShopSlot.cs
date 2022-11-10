using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopSlot : MonoBehaviour
{
    public OnSaleItem actualItem;

    [Header("UI")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemPrice;


    ShopScreenManager manager;
    [SerializeField] private SelectionBorder selectionTip;
    public void InitializeSlot(OnSaleItem itemToSale, ShopScreenManager man)
    {
        manager = man;
        actualItem = itemToSale;

        itemIcon.sprite = actualItem.item.itemIcon;
        itemPrice.text = actualItem.overridePrice.ToString();
        selectionTip.gameObject.SetActive(true);
    }

    public void SelectMe()
    {
        //TurnOn Effects
        //Tell manager that you are selected
        selectionTip.Clicked();
        manager.SelectSlot(this);

    }

    public void UnselectMe()
    {
        selectionTip.Unselect();
        //TurnOff Effects
    }
}
