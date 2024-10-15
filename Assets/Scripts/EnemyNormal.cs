using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormal : Enemy
{
    public GameObject enemySmall;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        speed = 3.0f;
        state = new EnemySearchState(this);
    }

    // Update is called once per frame
    void Update()
    {
        state.DoState();
    }

    override
    public GameObject clone()
    {
        return Instantiate(gameObject);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("LaserShot"))
        {
            addSmallEnemies(enemySmall);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
