using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {
    //Food Prefab
    public GameObject food;

    //Border
    public Transform border_Top;
    public Transform border_Bottom;
    public Transform border_Left;
    public Transform border_Right;

	// Use this for initialization
	void Start () {
		//spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, 4);
	}

    void Spawn()
    {
        // x position between left & right border
        int x = (int)Random.Range(border_Left.position.x, border_Right.position.x);

        //y position between top & bottom border
        int z = (int)Random.Range(border_Top.position.z, border_Bottom.position.z);

        //Instantiate the food at (x, y)
        Instantiate(food, new Vector3(x, 0.5f, z), Quaternion.identity);
    }

}
