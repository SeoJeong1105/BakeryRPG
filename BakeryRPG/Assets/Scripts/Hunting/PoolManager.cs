using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject prefab;

    private List<GameObject>[] enemyList;

    private void Awake() {
        enemyList = new List<GameObject>[1];

        for(int i = 0; i < enemyList.Length; i++)
        {
            enemyList[i] = new List<GameObject>();
        }
    }

    public GameObject GetEnemy(int idx)
    {
        GameObject select = null;

        foreach(GameObject item in enemyList[idx])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            } 
        }

        if(select == null)
        {
            select = Instantiate(prefab, transform);
            enemyList[idx].Add(select);
        }

        return select;
    }
}
