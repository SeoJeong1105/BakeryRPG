using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public static MenuPanel instance;
    public MenuSlot[] menuSlots;
    public GameObject slotParent;
    
    private void Awake() {
        instance = this;   
    }

    private void Start() {
        menuSlots = slotParent.GetComponentsInChildren<MenuSlot>();
    }

    public void UpdateMenu()
    {
        foreach (var slot in menuSlots)
        {
            slot.UpdateMenuSlot();
        }
    }

}
