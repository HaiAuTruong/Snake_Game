using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove_Ver2 : MonoBehaviour
{

    public float distance = 1f;
    public float time = 0.5f;
    public GameObject cube;

    private bool paused;
    private Vector3 newBodyPos;
    private int bodyCount = 1;
    
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //IF PAUSING THEN DO NOTHING
        if (paused)
            return;
        
        //ALWAYS MOVE TOWARD
        transform.position += transform.forward * distance;

        StartCoroutine(Pause());
    }

    //PAUSE THE SNAKE FOR X SECONDS
    private IEnumerator Pause()
    {
        paused = true;
        yield return new WaitForSeconds(time);
        paused = false;
    }

    void OnTriggerEnter(Collider col)
    {

        Vector3 newPos = new Vector3();
        switch (col.gameObject.name)
        {
            case "Right_Border":
                // Change parent transform
                newPos = GameObject.Find("Left_Border").transform.position;
                newPos.x += 1.5f;
                newPos.y = 0.5f;
                newPos.z = this.transform.position.z;
                transform.position = newPos;

                break;
            case "Left_Border":

                // Change parent transform
                newPos = GameObject.Find("Right_Border").transform.position;
                newPos.x -= 1.5f;
                newPos.y = 0.5f;
                newPos.z = this.transform.position.z;
                transform.position = newPos;

                break;
            case "Top_Border":

                // Change parent transform
                newPos = GameObject.Find("Bottom_Border").transform.position;
                newPos.z += 1.5f;
                newPos.y = 0.5f;
                newPos.x = this.transform.position.x;
                transform.position = newPos;

                break;
            case "Bottom_Border":

                // Change parent transform
                newPos = GameObject.Find("Top_Border").transform.position;
                newPos.z -= 1.5f;
                newPos.y = 0.5f;
                newPos.x = this.transform.position.x;
                transform.position = newPos;

                break;
            case "FoodPrefab(Clone)":

                newBodyPos = this.transform.position - bodyCount * transform.forward;
                bodyCount++;
                Destroy(col.gameObject);
                Instantiate(cube, newBodyPos, this.transform.rotation, this.transform);
         
                break;
        }

    }
}
