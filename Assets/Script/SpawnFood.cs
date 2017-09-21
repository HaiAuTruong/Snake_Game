using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {
    //Food Prefab
    public GameObject food;

    //Border
    private Transform border_Top;
    private Transform border_Bottom;
    private Transform border_Left;
    private Transform border_Right;

	// Use this for initialization
	void Start () {
		//spawn food every 4 seconds, starting in 3
        border_Top = GameObject.Find("Top_Border").transform;
        border_Bottom = GameObject.Find("Bottom_Border").transform;
        border_Left = GameObject.Find("Left_Border").transform;
        border_Right = GameObject.Find("Right_Border").transform;
        InvokeRepeating("Spawn", 3, 3);
	}

    void Spawn()
    {
        

        // x position between left & right border
        float x = Mathf.Round(Random.Range(border_Left.position.x + 6f, border_Right.position.x - 6f)) + 0.5f;

        //y position between top & bottom border
        float z = Mathf.Round(Random.Range(border_Top.position.z - 6f, border_Bottom.position.z + 6f)) + 0.5f;

        Vector3 spawnPos = new Vector3(x, 0.5f, z);
        //Instantiate the food at (x, y)
        Instantiate(food, spawnPos, Quaternion.identity,this.transform);
    }

}
