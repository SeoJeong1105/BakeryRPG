using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public List<Fruit> itemPool;
    public Fruit lastItem;
    public Transform itemGroup;
    public int poolSize = 5;
    public int poolCursor;

    private void Awake() {
        itemPool = new List<Fruit>();
        for(int i=0; i<poolSize; i++)
        {
            MakeItem();
        }
    }

    public void GameStart()
    {
        Invoke("NextItem", 0.1f);
    }

    public void GameOver()
    {
        foreach(var i in itemPool){
            if(i.gameObject.activeSelf) 
                i.gameObject.SetActive(false);
        }
    }

    private Fruit MakeItem()
    {
        GameObject ins = Instantiate(itemPrefab, itemGroup);
        ins.name = "Fruit" + itemPool.Count;
        ins.SetActive(false);
        Fruit insItem = ins.GetComponent<Fruit>();
        itemPool.Add(insItem);
        return insItem;
    }

    private Fruit GetItem()
    {
        for(int i=0; i<itemPool.Count; i++)
        {
            poolCursor = (poolCursor + 1) % itemPool.Count;
            if(!itemPool[poolCursor].gameObject.activeSelf)
                return itemPool[poolCursor];
        }
        return MakeItem();
    }

    private void NextItem()
    {
        if(FruitManager.instance.IsOver()) return;
        lastItem = GetItem();
        
        int x = Random.Range(-1, 1);
        lastItem.transform.position += new Vector3(x * 3.5f, 0, 0);

        float ratio = Random.Range(0f, 1f);

        lastItem.gameObject.SetActive(true);
        if(ratio > 0.5f) lastItem.isRotten = true;
        lastItem.UseGravity();

        StartCoroutine("WaitNext");
    }

    IEnumerator WaitNext()
    {
        yield return new WaitForSeconds(1f);
        NextItem();
    }
}
