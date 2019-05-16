using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] Enemies;
    int randomSpawnPoint, randomMonster;
    public static bool spawnAllowed;
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 0f, 1.4f);
    }

    void SpawnAMonster()
    {
        if(spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, Enemies.Length);
            Instantiate(Enemies[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }

}
