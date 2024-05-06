using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private Collider2D col;

    private void Awake() {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag != "Area") return;

        Vector3 playerPos = HuntManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        float difX = Mathf.Abs(dirX);
        float difY = Mathf.Abs(dirY);

        dirX = dirX < 0 ? -1 : 1;
        dirY = dirY < 0 ? -1 : 1; 

        switch(transform.tag)
        {
            case "Ground":
                if(difX > difY){
                    transform.Translate(Vector3.right * dirX * 60);
                }
                else if(difX < difY)
                {
                    transform.Translate(Vector3.up * dirY * 60);
                }
                break;

            case "Enemy":
                if(col.enabled)
                {
                    transform.Translate(HuntManager.instance.player.inputVec * 30 + new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f)));
                }
                break;
            
        }
    }
}
