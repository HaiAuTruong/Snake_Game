using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{

    public float Speed = 4f;
    private Vector3 Direction = Vector3.left;
    public float headDistance = 3f;
    public float clockwise = 1000.0f;
    public float counterClockwise = -5.0f;
    public GameObject cube;

    Vector3 newBodyPos;
    int bodyCount = 1;
    List<GameObject> bodyPart;
    // Use this for initialization
    void Start()
    {
        bodyPart = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, Time.deltaTime * clockwise, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
        }

        //transform.Translate(Direction * Time.deltaTime * Speed);
        transform.position += transform.forward * Time.deltaTime * Speed;
    }

    void OnTriggerEnter(Collider col)
    {
       
        Vector3 newPos = new Vector3();
        switch (col.gameObject.name)
        {
            case "Right_Border":
                // Change parent transform
                newPos = GameObject.Find("Left_Border").transform.position;
                newPos.x += 3f;
                newPos.y = 0.5f;
                newPos.z = this.transform.position.z;
                transform.position = newPos;

                break;
            case "Left_Border":
               
                // Change parent transform
                newPos = GameObject.Find("Right_Border").transform.position;
                newPos.x -= 3f;
                newPos.y = 0.5f;
                newPos.z = this.transform.position.z;
                transform.position = newPos;

                break;
            case "Top_Border":
                
                // Change parent transform
                newPos = GameObject.Find("Bottom_Border").transform.position;
                newPos.z += 3f;
                newPos.y = 0.5f;
                newPos.x = this.transform.position.x;
                transform.position = newPos;

                break;
            case "Bottom_Border":
                
                // Change parent transform
                newPos = GameObject.Find("Top_Border").transform.position;
                newPos.z -= 3f;
                newPos.y = 0.5f;
                newPos.x = this.transform.position.x;
                transform.position = newPos;

                break;
            case "FoodPrefab(Clone)":

                newBodyPos = this.transform.position - bodyCount * transform.forward;
                bodyCount++;
                bodyPart.Add(Instantiate(cube, newBodyPos, this.transform.rotation, this.transform) as GameObject);
                Destroy(col.gameObject);
                break;
        }

    }


}
