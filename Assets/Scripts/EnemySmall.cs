using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        speed = 4.0f;
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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
