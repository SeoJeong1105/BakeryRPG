using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HuntManager : MonoBehaviour
{
    public static HuntManager instance;

    [Header("Game Object")]
    public PoolManager pool;
    public WeaponController controller;
    public Player player;

    [Header("Game Control")]
    public bool isStarted = false;
    public float time;
    public float maxTime = 60f;

    [Header("Player Info")]
    public float hp;
    public float maxHP = 100;
    public int weaponLevel;
    public int kill;
    public int exp;

    [Header("UI")]
    public GameObject playGroup;
    public GameObject endGroup;
    public Text expTxt;
    public Text killTxt;

    private void Awake() { 
        instance = this;
    }

    private void Update() {
        if (!isStarted) return;
        time += Time.deltaTime;
        if(time > maxTime) {
            time = maxTime;
        }

        if(time == maxTime || hp <= 0){
            GameOver();
        }
    }

    public void GameStart()
    {
        isStarted = true;
        player.isActive = true;
        controller.GameStart();

        time = 0;
        hp = maxHP;
    }

    public void GameOver()
    {
        StartCoroutine("GameOverRoutine");
    }

    IEnumerator GameOverRoutine()
    {
        isStarted = false;
        player.isActive = false;
        yield return new WaitForSeconds(0.5f);
        playGroup.SetActive(false);
        endGroup.SetActive(true);
        
        Information.instance.SetExp(exp);
        expTxt.text = exp.ToString();
        killTxt.text = kill.ToString();
    }

    public void GetExp(int lev)
    {
        exp += lev;
    }

    public void BackToBakery()
    {
        SceneManager.LoadScene("Bakery");
    }
}
