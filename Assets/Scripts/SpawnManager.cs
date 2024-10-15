using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRangeX = 20;
    private float spawnRangeZ = 20;
    private float spawnYLocate = 20;

    private float startDelay = 0f;
    private float spawnInterval = 5f;

    private int maxEnemies = 10;

    public GameObject enemy;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > maxEnemies)
        {
            CancelInvoke("SpawnEnemy");
        }
    }

    void SpawnEnemy()
    {
        float xPos;
        float xPos1 = Random.Range(player.transform.position.x + 10, player.transform.position.x + 10 + spawnRangeX);
        float xPos2 = Random.Range(player.transform.position.x - 10 - spawnRangeX, player.transform.position.x - 10);

        float zPos;
        float zPos1 = Random.Range(player.transform.position.z + 10, player.transform.position.z + 10 + spawnRangeZ);
        float zPos2 = Random.Range(player.transform.position.z - 10 - spawnRangeZ, player.transform.position.z - 10);

        if (Random.Range(0,2) < 1)
        {
            xPos = xPos1;
        }

        else
        {
            xPos = xPos2;
        }

        if (Random.Range(0, 2) < 1)
        {
            zPos = zPos1;
        }

        else
        {
            zPos = zPos2;
        }

        Vector3 spawnPos = new Vector3(xPos, spawnYLocate, zPos);

        Instantiate(enemy, spawnPos, enemy.transform.rotation);
    }
}
