using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Item item;
    
    [Header("UI")]
    public Text nameTxt;
    public Text priceTxt;
    public Image itemImage;

    private void Awake() {
        nameTxt.text = item.itemName;
        priceTxt.text = item.itemPrice.ToString();
        itemImage.sprite = item.itemImage;
    }

    public void SelectItem()
    {
        if(item.itemPrice > Information.instance.GetMoney()){
            MarketManager.instance.PopUpMessage(0);
            return;
        }
        Information.instance.SetMoney(-item.itemPrice);
        Inventory.instance.AcquiredItem(item);
    }

}
