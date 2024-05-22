using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oven : MonoBehaviour
{
    public Button makeBtn;
    public Slider slider;
    public Button completeBtn;
    public Menu menu;
    public Image menuImage;
    public Image completeImage;
    private float curTime = 0f;

    private void OnTriggerStay2D(Collider2D other) {
        if(completeBtn.IsActive())
            completeBtn.interactable = true;
        else if(!slider.IsActive())
            makeBtn.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        makeBtn.gameObject.SetActive(false);
        if(completeBtn.IsActive())
            completeBtn.interactable = false;
    }
    
    private void LateUpdate() {
        if(!slider.IsActive()) return;
        curTime += Time.deltaTime;
        slider.value = curTime;
        if(slider.value == slider.maxValue){
            Complete();
        }
    }
    public void OnClickMakeButton()
    {
        BakeryManager.instance.oven = this;
        BakeryManager.instance.OpenMenu();
    }

    public void Making()
    {
        slider.maxValue = menu.time;
        makeBtn.gameObject.SetActive(false);
        slider.gameObject.SetActive(true);
        menuImage.sprite = menu.menuImage;
        curTime = 0;
    }

    public void Complete()
    {
        slider.gameObject.SetActive(false);
        completeBtn.gameObject.SetActive(true);
        completeImage.sprite = menu.menuImage;
        completeBtn.interactable = false;
    }

    public void OnClickCompleteButton()
    {
        if(!completeBtn.interactable) return;
        completeBtn.gameObject.SetActive(false);
        Display.instance.AddMenu(menu);
    }
}
