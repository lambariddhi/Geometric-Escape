using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CubeDecoratorFile;

public class CubeManager : MonoBehaviour
{
    public GameObject nextCube;
    public bool hasMerged = false;

    public ICubeDecorator currentCubeDecorator = new BaseCubeDecorator(new Cube());

    public Enemy enemyData;

    // Start is called before the first frame update
    void Start()
    {
        enemyData = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        //intentionally left empty, only runs collision checker
    }

    void ApplyDecorator(int decoratorID, ICubeDecorator decorator)
    {
        switch (decoratorID)
        {
            case 0:
                enemyData.speed = 2;
                break;
            case 1:
                //makes a new material
                PhysicMaterial bouncyMaterial = new PhysicMaterial();
                bouncyMaterial.bounciness = 2;

                //applies this material
                gameObject.GetComponent<Collider>().material = bouncyMaterial;
                break;
            case 2:
                //retries the red material
                Material redMaterial = new Material(Shader.Find("RedMaterial"));
                //applies
                gameObject.GetComponent<Renderer>().material = redMaterial;
                break;
            case 3:
                //same as case 2
                Material blueMaterial = new Material(Shader.Find("BlueMaterial"));
                gameObject.GetComponent<Renderer>().material = blueMaterial;
                break;
            default:
                Debug.Log("Unknown ID");
                break;

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the other GameObject with a box collider
        if (!hasMerged && collision.gameObject.CompareTag(tag))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

            GameObject newCube = Instantiate(nextCube, transform.position, transform.rotation);
            hasMerged = true;

            int decoratorToAdd = Random.Range(0, 4);

            switch (decoratorToAdd)
            {
                case 0:
                    newCube?.GetComponent<CubeManager>().ApplyDecorator(0, new SpeedyCube(currentCubeDecorator));
                    Debug.Log("Speedy cube decorator added.");
                    break;
                case 1:
                    newCube?.GetComponent<CubeManager>().ApplyDecorator(1, new JumpyCube(currentCubeDecorator));
                    Debug.Log("Jumpy cube decorator added.");
                    break;
                case 2:
                    newCube?.GetComponent<CubeManager>().ApplyDecorator(2, new RedCube(currentCubeDecorator));
                    Debug.Log("Red cube decorator added.");
                    break;
                case 3:
                    newCube?.GetComponent<CubeManager>().ApplyDecorator(3, new BlueCube(currentCubeDecorator));
                    Debug.Log("Blue cube decorator added.");
                    break;
                default:
                    Debug.Log("No decorator added.");
                    break;
            }
        }

    }

}

