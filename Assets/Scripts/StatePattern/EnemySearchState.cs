using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchState : EnemyState
{
    public EnemySearchState(Enemy enemy) : base(enemy)
    {

    }

    override
    public void DoState()
    {
        if ((player.transform.position - enemy.transform.position).magnitude < 10)
        {
            enemy.state = new EnemyFollowState(enemy);
        }

        else
        {
            enemy.state = new EnemyWanderState(enemy);
        }
    }
}
