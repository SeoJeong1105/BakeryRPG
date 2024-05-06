using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int idx;
    public SaleList saleList;

    private bool inTrigger;

    [Header("UI")]
    public Button shopBtn;
    public Image buyImage;

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag != "Player") return;
        buyImage.gameObject.SetActive(true);
        shopBtn.gameObject.SetActive(true);
        inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag != "Player") return;
        buyImage.gameObject.SetActive(false);
        shopBtn.gameObject.SetActive(false);
        inTrigger = false;
    }

    public void OnClickShopButton()
    {
        if(!inTrigger) return;
        saleList.OpenList();
    }
}
