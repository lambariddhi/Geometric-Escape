using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float xBound = 100;
    public float yBound = 100;
    public float zBound = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (transform.position.x > xBound || transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }

        else if (transform.position.y > yBound || transform.position.y < -yBound)
        {
            Destroy(gameObject);
        }

        else if (transform.position.z > zBound || transform.position.z < -zBound)
        {
            Destroy(gameObject);
        }

    }
}
