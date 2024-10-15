using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowState : EnemyState
{
    private float followTime = 300;

    public EnemyFollowState(Enemy enemy) : base(enemy)
    {
    }

    override
    public void DoState()
    {
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, speed*Time.deltaTime);

        followTime--;

        if (followTime == 0)
        {
            enemy.state = new EnemySearchState(enemy);
            followTime = 150;
        }
    }
}
