using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public SpawnData[] spawnData;

    private float timer;
    int level;

    private void Awake() {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    private void Update() {
        if(!HuntManager.instance.isStarted) return;
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(HuntManager.instance.time / 10f), 4);
        if(timer > spawnData[level].spawnTime){
            timer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject enemy = HuntManager.instance.pool.GetEnemy(0);
        enemy.transform.position = spawnPoints[Random.Range(1,spawnPoints.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

[System.Serializable]
public class SpawnData
{
    public int level;
    public float spawnTime;
    public int spriteType;
    public int hp;
    public float speed;
}
