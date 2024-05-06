using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    public static MarketManager instance;

    [Header("UI")]
    public Text moneyTxt;
    public Text expTxt;
    public Image popup;
    public Text popupTxt;

    private String[] popupMessages = {
        "돈이 부족합니다",
        "경험치가 부족합니다",
    }; 
    
    private void Awake() {
        instance = this;    
    }

    private void LateUpdate() {
        moneyTxt.text = Information.instance.GetMoney().ToString();
        expTxt.text = Information.instance.GetExp().ToString();
    }

    public void PopUpMessage(int idx)
    {
        popup.gameObject.SetActive(true);
        popupTxt.text = popupMessages[idx];
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        popup.gameObject.SetActive(false);
    }
}
