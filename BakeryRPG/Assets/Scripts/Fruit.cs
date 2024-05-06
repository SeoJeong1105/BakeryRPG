using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    SphereCollider col;
    Animator anim;
    Rigidbody2D rigid;

    public bool isRotten;

    private void Awake()
    {
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnDisable() {
        isRotten = false;
        rigid.gravityScale = 0;
        transform.localPosition = new Vector3(0, 12, 0);
        rigid.velocity = Vector3.zero;
    }

    public void UseGravity()
    {
        anim.SetBool("isRotten", isRotten);
        rigid.gravityScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Fruit") return;
        if(other.gameObject.tag == "Player")
        {
            if(!isRotten)
                FruitManager.instance.score++;
            else
                FruitManager.instance.LoseHeart();
        }
        gameObject.SetActive(false);
    }

}
