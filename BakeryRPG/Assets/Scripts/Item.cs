using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "NewItem/Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Equipment,
        Ingredient,
        ETC,
    }

    public string itemName;
    public int itemPrice;
    public Sprite itemImage;
    public ItemType itemType;

    public bool Use()
    {
        return false;
    }   
}
