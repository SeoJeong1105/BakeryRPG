using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuSlot : MonoBehaviour
{
    public Menu menu;
    public Text menuName;
    public Image menuImage;
    public Text piece;
    public Text time;
    public List<Image> images;

    private List<Item> ingredients;
    private Button btn;

    private void Awake() {
        btn = GetComponent<Button>();
    }

    private void Start() {
        if(menu == null) return;

        menuName.text = menu.menuName;
        menuImage.sprite = menu.menuImage;
        piece.text = menu.piece + " 개";
        time.text = menu.time + " 초";
        ingredients = menu.ingredients;

        for(int i=0; i<menu.ingredients.Count; i++)
        {
            images[i].sprite = ingredients[i].itemImage;
        }
    }

    private void UseIngredient()
    {
        for(int i=0; i<ingredients.Count; i++)
        {
            for(int j=0; j<Inventory.instance.slots.Length; j++)
            {
                Slot slot = Inventory.instance.slots[j];
                if(slot.item != null && slot.item.itemName == ingredients[i].itemName){
                    slot.SetSlotCount(-1);
                    break;
                }
            }
        }
    }

    public void UpdateMenuSlot()
    {
        bool isLack = false;
        for(int i=0; i<ingredients.Count; i++)
        {
            for(int j=0; j<Inventory.instance.slots.Length; j++)
            {
                Slot slot = Inventory.instance.slots[j];
                if(slot.item != null && slot.item.itemName == ingredients[i].itemName)
                    break;
                if(j == Inventory.instance.slots.Length - 1)
                    isLack = true;
            }
            if(isLack) break;
            // var slot = Array.Find(Inventory.instance.slots, x => x.item.itemName == ingredients[i].itemName);
            // if(slot == null || slot.itemCount == 0){
            //     isLack = true;
            //     break;
            // }
        }
        if(isLack)
            btn.interactable = false;
        else
            btn.interactable = true;
    }

    public void OnButtonClick()
    {
        UseIngredient();
        BakeryManager.instance.StartMaking(menu);
        Debug.Log(menu.menuName);
        UpdateMenuSlot();
    }
}
