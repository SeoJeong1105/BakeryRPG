using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D target;
    public float speed;
    public float hp;
    public float maxHP;
    public int level;
    public RuntimeAnimatorController[] animCon;

    private bool isLive;

    private Rigidbody2D rigid;
    private Collider2D col;
    private Animator animator;
    private SpriteRenderer spriteRend;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        target = HuntManager.instance.player.GetComponent<Rigidbody2D>();    
        isLive = true;    
        rigid.simulated = true;
        col.enabled = true;
        spriteRend.sortingOrder = 2;
        animator.SetBool("Dead", false);
        hp = maxHP;
    }

    private void FixedUpdate() {
        if (!isLive || animator.GetCurrentAnimatorStateInfo(0).IsName("Hit")) return;
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate() {
        if (!isLive) return;
        spriteRend.flipX = target.position.x < rigid.position.x;
    }

    public void Init(SpawnData data)
    {
        animator.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHP = data.hp;
        hp = maxHP;
        level = data.level;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!isLive || other.tag != "Weapon") return;
        hp -= other.GetComponentInChildren<Weapon>().damage;
        StartCoroutine("KnockBack");

        if(hp > 0){
            animator.SetTrigger("Hit");
        }
        else{
            isLive = false;
            rigid.simulated = false;
            col.enabled = false;
            spriteRend.sortingOrder = 1;
            animator.SetBool("Dead", true);
            HuntManager.instance.kill++;
            HuntManager.instance.GetExp(level);
        }   
    }

    private void Dead()
    {
        gameObject.SetActive(false);
    }   

    IEnumerator KnockBack()
    {
        yield return new WaitForFixedUpdate();
        Vector3 playerPos = HuntManager.instance.player.transform.position;
        Vector3 dir = transform.position - playerPos;
        rigid.AddForce(dir.normalized * 2, ForceMode2D.Impulse);
    }

}
