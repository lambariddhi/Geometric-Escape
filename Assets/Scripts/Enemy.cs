using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IPrototype
{
    public GameObject player;

    private float xRange = 20;
    private float zRange = 20;

    public float speed;

    public abstract GameObject clone();

    public EnemyState state;

    public void addSmallEnemies(GameObject e)
    {
        Vector3 newPos = new Vector3(Random.Range(-xRange, xRange), 0f, Random.Range(-zRange, zRange));
        Instantiate(e, newPos, e.transform.rotation);

        EnemySmall enemySmall = e.GetComponent<EnemySmall>();

        int cloneNum = Random.Range(1, 3);

        for (int i = 0; i < cloneNum; i ++)
        {
            float xPos;
            float xPos1 = Random.Range(player.transform.position.x + 10, player.transform.position.x + 10 + xRange);
            float xPos2 = Random.Range(player.transform.position.x - 10 - xRange, player.transform.position.x - 10);

            float zPos;
            float zPos1 = Random.Range(player.transform.position.z + 10, player.transform.position.z + 10 + zRange);
            float zPos2 = Random.Range(player.transform.position.z - 10 - zRange, player.transform.position.z - 10);

            if (Random.Range(0, 2) < 1)
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

            newPos = new Vector3(xPos, 0, zPos);
            Instantiate(enemySmall.clone(), newPos, enemySmall.clone().transform.rotation);
        }
    }
}
