using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWanderState : EnemyState
{
    private float wanderTime = 100;
    private float xRange = 20;
    private float zRange = 20;

    Vector3 randomPos;

    public EnemyWanderState(Enemy enemy) : base(enemy)
    {
        randomPos = new Vector3(Random.Range(-xRange, xRange), 0f, Random.Range(-zRange, zRange));
    }

    override
    public void DoState()
    {
       enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, randomPos, speed * Time.deltaTime);

       wanderTime--;

       if (wanderTime == 0)
        {
            enemy.state = new EnemySearchState(enemy);
            wanderTime = 100;
        }
    }
}
