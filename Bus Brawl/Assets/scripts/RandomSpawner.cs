using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    float timeToSpawn = 2.0f;
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;


    // Update is called once per frame
    void Update() // spawning enemys from enemy prefabs, every 2 sec.
    {
        timeToSpawn -= Time.deltaTime; // bug - the spawner doenst spawn with childern (canvas and hp)
        if (timeToSpawn <= 0)
        {
            timeToSpawn = 0;
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            int randEnemyPoint = Random.Range(0, enemyPrefabs.Length);
            var enemy = Instantiate(enemyPrefabs[randEnemyPoint], spawnPoints[randSpawnPoint].position, transform.rotation);
            int nameofenemy = Random.Range(0,999999999);
            enemy.name = (nameofenemy.ToString("F0"));
            timeToSpawn = 2;
        }
    }

}