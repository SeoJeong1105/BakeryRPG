using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Weed : MonoBehaviour, IPointerClickHandler
{
    private Image img;
    private System.Random rand = new System.Random();

    public int idx;
    public bool isWeed = false;

    public List<Sprite> randomWeeds;
    public Sprite dirt;

    private void Awake() {
        img = GetComponent<Image>();
    }

    public void GrowWeed()
    {
        if(isWeed) return;
        isWeed = true;
        idx = rand.Next(0, 4);
        img.sprite = randomWeeds[idx];
    }

    public void PullWeed()
    {   
        isWeed = false;
        img.sprite = dirt;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isWeed) return;
        WheatManager.instance.score++;
        PullWeed();
    }


}
