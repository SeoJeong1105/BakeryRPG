using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheat : MonoBehaviour
{
    private System.Random rand = new System.Random();
    public List<Weed> Weeds;
    public int idx;
    private float delay = 0.5f;

    public void GameStart()
    {
        Invoke("NextIdx", 0.5f);
    }

    private void NextIdx()
    {
        if(WheatManager.instance.IsOver()) return;
        idx = rand.Next(0, 12);
        Weeds[idx].GrowWeed();
        StartCoroutine("WaitNext");
    }

    IEnumerator WaitNext()
    {
        yield return new WaitForSeconds(delay);
        if(delay > 0.2f)
            delay -= 0.015f;
        NextIdx();
    }
}
