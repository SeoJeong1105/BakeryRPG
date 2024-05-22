using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BakeryManager : MonoBehaviour
{
    public static BakeryManager instance;
    [Header("Game Object")]
    public Player player;
    public Customer customer;
    public Oven oven;
    public MenuPanel menuPanel;

    [Header("Game Info")]
    public int day = 1;
    public int money = 0;
    public int reputation = 0;

    [Header("UI")]
    public GameObject startGroup;
    public GameObject playGroup;
    public GameObject endGroup;
    public RectTransform menuTransform;

    private void Awake() {
        instance = this;
    }

    public void OpenMenu()
    {
        menuTransform.anchoredPosition = Vector2.zero;
        menuPanel.UpdateMenu();
    }

    public void CloseMenu()
    {
        menuTransform.anchoredPosition = Vector2.down * 1500;
    }

    public void StartMaking(Menu menu)
    {
        CloseMenu();
        oven.menu = menu;
        oven.Making();
    }

    public void GetMoney(int num, int price)
    {
        money += num * price;
        reputation++;
    }

    // 베이커리 영업 시작
    public void OnClickOpenButton()
    {
        startGroup.SetActive(false);
        playGroup.SetActive(true);
        customer.GameStart();
    }

    // 베이커리 영업 종료
    public void OnClickCloseButton()
    {
        customer.GameOver();
        playGroup.SetActive(false);
        endGroup.SetActive(true);

        Information.instance.SetMoney(money);
        Information.instance.SetReputation(reputation);
    }

    // 다음 날로 전환
    public void OnClickNextDayButton()
    {
        endGroup.SetActive(false);
        startGroup.SetActive(true);

        day++;        
        money = 0; 
        reputation = 0;
        Display.instance.ResetMenu();
    }

}
