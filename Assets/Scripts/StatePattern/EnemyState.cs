using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : MonoBehaviour, IEnemyState
{
    protected Enemy enemy;
    protected GameObject player;
    protected float speed;

    public EnemyState(Enemy enemy)
    {
        this.enemy = enemy;
        this.player = enemy.player;
        this.speed = enemy.speed;
    }

    public abstract void DoState();
}
