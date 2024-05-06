using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuntHUD : MonoBehaviour
{
    public enum InfoType {Time, Exp, Kill, HP}
    public InfoType type;
    Text text;
    Slider slider;

    private void Awake() {
        text = GetComponent<Text>();
        slider = GetComponent<Slider>();
    }

    private void Update() {
        if(!HuntManager.instance.isStarted) return;
        switch (type) {
            case InfoType.Time:
                float remainTime = HuntManager.instance.maxTime - HuntManager.instance.time;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                text.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;

            case InfoType.Exp:
                text.text = HuntManager.instance.exp.ToString();
                break;

            case InfoType.Kill:
                text.text = HuntManager.instance.kill.ToString();
                break;
                
            case InfoType.HP:
                float curHP = HuntManager.instance.hp;
                float maxHP = HuntManager.instance.maxHP;
                slider.value = curHP / maxHP;
                break;

        }
    }
}
