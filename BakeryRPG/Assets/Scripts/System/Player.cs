using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public bool isActive = false;

    private Rigidbody2D rigid;
    private Animator anim;
    private SpriteRenderer spriteRend;
    
    public FloatingJoystick joy;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        if(!isActive){
            anim.SetBool("Walk", false);            
            return;
        }
        
        inputVec.x = joy.Horizontal;
        inputVec.y = joy.Vertical;

        if(inputVec.x == 0 && inputVec.y == 0){
            anim.SetBool("Walk", false);
            return;
        }            
        else
            anim.SetBool("Walk", true);

        if(inputVec.x < 0)
            spriteRend.flipX = true;
        else if(inputVec.x > 0)
            spriteRend.flipX = false;

        Vector2 nextVec = inputVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    public void IsActive(bool b)
    {
        isActive = b;
    }

    public bool IsLeft()
    {
        return spriteRend.flipX;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(tag != "HuntPlayer") return; 
        if(!HuntManager.instance.isStarted) return;
        HuntManager.instance.hp -= Time.deltaTime * 10;

        if(HuntManager.instance.hp < 0){
            anim.SetTrigger("Attacked");
        }
    }
}
