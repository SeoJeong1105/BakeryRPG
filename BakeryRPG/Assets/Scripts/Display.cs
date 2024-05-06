using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public static Display instance;
    public Customer customer;
    public GameObject displayUI;
    public Button menuBtn;
    public Text countTxt;
    public Image menuImage;
    private int count = 0;

    private void Awake() {
        instance = this;
    }

    private void LateUpdate() {
        countTxt.text = count.ToString();
    }

    public void AddMenu(Menu menu)
    {
        if(menuImage.sprite == null){
            displayUI.SetActive(true);
            menuImage.sprite = menu.menuImage;
        }
        count += menu.piece;
    }

    public void OnClickMenuButton()
    {
        if(!menuBtn.interactable) return;
        if(count > 0){
            customer.Serving();
            count--;
        }
    }

    public void ResetMenu()
    {
        menuImage.sprite = null;
        count = 0;
        displayUI.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {  
        menuBtn.interactable = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        menuBtn.interactable = false;
    }

}
