using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheatManager : MonoBehaviour
{
    public static WheatManager instance;
    public Wheat wheat;
    public float maxTime;
    private float leftTime;
    public Item item;

    [Header("UI")]
    public GameObject startGroup;
    public GameObject endGroup;
    public Slider slider;
    public Text scoreTxt;
    public Text endScore;
    
    public int score = 0;

    private void Awake() {
        instance = this;
    }

    private void LateUpdate()
    {
        if(startGroup.activeSelf) return;
        leftTime -= Time.deltaTime;
        slider.value = leftTime;
        scoreTxt.text = score + "";
    }

    public void GameStart()
    {   
        leftTime = maxTime;
        slider.maxValue = maxTime;
        slider.value = maxTime;
        startGroup.SetActive(false);
        wheat.GameStart();
    }

    public void GameOver()
    {
        endScore.text = score + "";
        endGroup.SetActive(true);
        Inventory.instance.AcquiredItem(item, score);
    }

    public bool IsOver()
    {
        if(leftTime > 0f) 
            return false;
        else {
            GameOver();
            return true;
        }
    }

    public void BackButton()
    {
        score = 0;
        endGroup.SetActive(false);
        startGroup.SetActive(true);
    }

}
