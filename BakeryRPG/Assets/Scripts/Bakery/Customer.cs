using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public List<Sprite> randomSprites = new List<Sprite>();
    public float time;

    [Header("Order")]
    public GameObject order;
    public Image menuImage;
    public Text numTxt;

    private SpriteRenderer customer;
    private MenuSlot menuSlot;
    private bool isOver = false;
    private int maxNum = 5;
    private int orderNum;
    
    private void Awake() {
        customer = GetComponentInChildren<SpriteRenderer>();
    }

    public void GameStart()
    {
        isOver = false;
        Invoke("NewCustomer", 10f);
    }

    public void GameOver()
    {
        order.SetActive(false);
        isOver = true;
        customer.sprite = null;
    }

    private void NewCustomer()
    {   
        if(isOver) return;
        order.SetActive(true);
        // 손님 외형 결정
        int idx = Random.Range(0, randomSprites.Count);
        customer.sprite = randomSprites[idx];

        // 손님 메뉴 결정
        idx = Random.Range(0, MenuPanel.instance.menuSlots.Length);
        menuSlot = MenuPanel.instance.menuSlots[idx];
        menuImage.sprite = menuSlot.menu.menuImage;
        orderNum = Random.Range(1, maxNum);
        numTxt.text = orderNum.ToString();

        // 손님 메뉴 받을 때까지 기다림
        StartCoroutine("WaitServing", orderNum);
    }  

    public void Serving()
    {
        orderNum--;
        numTxt.text = orderNum.ToString();
    }

    IEnumerator WaitServing(int num)
    {
        while(orderNum > 0)
        {
            yield return new WaitForSeconds(0);        
        }
        // 서빙 완료, 기존 손님 나가고 새로운 손님 들어옴
        order.SetActive(false);
        customer.sprite = null;
        BakeryManager.instance.GetMoney(num, menuSlot.menu.price);
        StartCoroutine("WaitNext");

    }

    IEnumerator WaitNext()
    {
        yield return new WaitForSeconds(time);
        NewCustomer();
    }

}
