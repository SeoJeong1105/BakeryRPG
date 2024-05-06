using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BakeryHUD : MonoBehaviour
{
    public enum InfoType{ day, money, reputation, totalMoney, totalReputation }
    public InfoType bakeryInfo;

    private Text txt;

    private void Awake() {
        txt = GetComponent<Text>();
    }

    private void Update() {
        switch (bakeryInfo) {
            case InfoType.day:
                txt.text = string.Format("DAY {0}", BakeryManager.instance.day.ToString());
                break;
            case InfoType.money:
                txt.text = BakeryManager.instance.money.ToString();
                break;
            case InfoType.reputation:
                txt.text = BakeryManager.instance.reputation.ToString();
                break;
            case InfoType.totalMoney:
                txt.text = Information.instance.GetMoney().ToString();
                break;
            case InfoType.totalReputation:
                txt.text = Information.instance.GetReputation().ToString();
                break;
        }  
    }
    
}
