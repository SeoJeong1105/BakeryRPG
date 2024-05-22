using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public int itemCount;
    public Image itemImage;

    public Text textCount;
    public GameObject countImage;

    private void SetColor(float alpha)
    {
        Color color = itemImage.color;
        color.a = alpha;
        itemImage.color = color;
    }

    public void AddItem(Item it, int count = 1)
    {
        item = it;
        itemCount = count;
        itemImage.sprite = it.itemImage;

        if(item.itemType != Item.ItemType.Equipment)
        {
            countImage.SetActive(true); 
            textCount.text = count.ToString();
        }
        else
        {
            textCount.text = "0";
            countImage.SetActive(false); 
        }

        SetColor(1);
    }

    public void SetSlotCount(int count)
    {
        itemCount += count;
        textCount.text = itemCount.ToString();

        if(itemCount <= 0)
            ClearSlot();
    }

    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);
        textCount.text = "0";
        countImage.SetActive(false);
    }
}
