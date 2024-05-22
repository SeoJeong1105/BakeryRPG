using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public static FruitManager instance;
    public Player player;
    public PoolingManager pool;
    public Item item;

    [Header("UI")]
    public GameObject startGroup;
    public GameObject endGroup;

    public List<Image> Heart;
    public Sprite emptyHeart, fullHeart;
    public Text scoreTxt;
    public Text endScore;

    public int score = 0;
    public int heart = 3;
    private bool isOver = false;

    private void Awake() {
        instance = this;
    }

    private void LateUpdate() {
        scoreTxt.text = score + "";
    }

    public void LoseHeart()
    {
        heart--;
        Heart[heart].sprite = emptyHeart;
        if(heart == 0)
            GameOver();
    }

    public void GameStart()
    {
        isOver = false;
        score = 0;
        heart = 3;

        for(int i=0; i<3; i++)
        {
            Heart[i].sprite = fullHeart;
        }

        player.IsActive(true);
        startGroup.SetActive(false);
        pool.GameStart();
    }

    public void GameOver()
    {
        if(isOver) return;
        isOver = true;
        player.IsActive(false);
        endScore.text = score + "";
        endGroup.SetActive(true);
        pool.GameOver();

        Inventory.instance.AcquiredItem(item, score);
    }

    public bool IsOver()
    {
        return isOver;
    }

    public void BackButton()
    {
        endGroup.SetActive(false);
        startGroup.SetActive(true);
    }

}
