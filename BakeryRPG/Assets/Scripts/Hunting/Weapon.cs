using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;

    public void Init(float damage)
    {
        this.damage = damage;
    }
}
