using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public static bool inventoryActivated = false;
    public GameObject inventory;
    public GameObject slotParent;
    public Slot[] slots;
    public RectTransform inventoryUI;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    public void InventoryOpen()
    {
        if(inventoryUI.anchoredPosition == Vector2.zero)
            inventoryUI.anchoredPosition = Vector2.down * 1500;
        else
            inventoryUI.anchoredPosition = Vector2.zero;
    }

    public void AcquiredItem(Item item, int count = 1)
    {
        if(item.itemType != Item.ItemType.Equipment){
            for(int i=0; i<slots.Length; i++)
            {
                if(slots[i].item == null) continue;
                if(slots[i].item.itemName == item.itemName)
                {
                    slots[i].SetSlotCount(count);
                    return;
                }
            }
        }

        for(int i=0; i<slots.Length; i++)
        {
            if(slots[i].item == null)
            {
                slots[i].AddItem(item, count);
                return;
            }
        }
    }

}
