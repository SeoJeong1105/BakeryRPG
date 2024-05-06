using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    public static Information instance;

    [SerializeField]
    private int reputation;
    [SerializeField]
    private int money;
    [SerializeField]
    private int exp;

    private void Awake() {
        if(instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

    }

    public int GetReputation()
    {
        return reputation;
    }

    public int GetMoney()
    {
        return money;
    }

    public int GetExp()
    {
        return exp;
    }

    public void SetMoney(int m)
    {
        money += m;
    }

    public void SetReputation(int r)
    {
        reputation += r;
    }    

    public void SetExp(int e)
    {
        exp += e;
    }
}
