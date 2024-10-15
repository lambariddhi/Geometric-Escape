using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float horizontalInput;
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);
    //public float rotationalSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position + offset;
        Vector3 back = -player.transform.forward;
        back.y = 0.5f; 
        transform.position = player.transform.position - back * -7;

        transform.forward = player.transform.position - transform.position;

        ////rotate the camera based on player rotation
        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.up * horizontalInput);
    }
}
