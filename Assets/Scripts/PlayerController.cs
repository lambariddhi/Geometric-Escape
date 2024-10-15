using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;

    private int xRange = 150;

    private int speed = 7;
    private int rotationalSpeed = 50;

    public GameObject projectilePrefab;
    public GameObject laserGun;

    public float reloadTime = 500;
    public bool canShoot = true;

    //private CharacterController characterController;
    private Rigidbody rb;

    //adding gravity
    //private float _gravity = -2f;
    //[SerializeField] private float gravityMult = 2.0f;
    //private float _gravityVelocity;

    // Start is called before the first frame update
    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //Character Controller Code
        //horizontalInput = Input.GetAxis("orizontal");

        //transform.Rotate(0, horizontalInput, 0);

        //_gravityVelocity = _gravity * gravityMult * Time.deltaTime;
        //Vector3 playerMovement = new Vector3(horizontalInput, 0f, verticalInput);

        //characterController.Move(playerMovement * speed * Time.deltaTime);

        //if (playerMovement.magnitude != 0)
        //{
        //    transform.rotation = Quaternion.LookRotation(playerMovement);
        //}

        LateralMovement();


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canShoot)
            {
                Instantiate(projectilePrefab, transform.position + transform.forward, projectilePrefab.transform.rotation);
                canShoot = false;
            }
        }


        else if (!canShoot)
        {
            reloadTime--;

            if (reloadTime == 0)
            {
                canShoot = true;
                reloadTime = 150;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0;
        }
    }

    void LateralMovement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * rotationalSpeed);


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.up * 20, ForceMode.Impulse);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

}
