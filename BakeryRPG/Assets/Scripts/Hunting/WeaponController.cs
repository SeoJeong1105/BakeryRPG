using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponController : MonoBehaviour
{
    public Animator playerAnim;
    public List<Sprite> weaponSprites;
    public float damage;

    private Animator anim;
    private SpriteRenderer weaponSprite;

    private void Awake() {
        anim = GetComponent<Animator>();
        weaponSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void GameStart() {
        weaponSprite.sprite = weaponSprites[HuntManager.instance.weaponLevel];
        damage = (HuntManager.instance.weaponLevel + 1) * 10;
        Init();
    }

    private void Update() {
        // 캐릭터가 바라보는 방향에 따라 무기 위치 이동
        if (HuntManager.instance.player.inputVec.x == 0) return;
        int posX = HuntManager.instance.player.IsLeft() ? -1 : 1;
        transform.localPosition = new Vector3(posX, -0.9f, 0);
    }

    public void Init()
    {
        GetComponentInChildren<Weapon>().Init(damage);    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;
        if(other.tag == "Enemy")
        {
            if(HuntManager.instance.player.IsLeft())    
                anim.SetTrigger("LeftAttack");
            else    
                anim.SetTrigger("RightAttack");
        }
    }

    public void Attack()
    {
        playerAnim.SetTrigger("Attack");
    }
}
