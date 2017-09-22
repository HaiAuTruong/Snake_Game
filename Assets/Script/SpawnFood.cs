using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    //Food Prefab
    public GameObject smallFood;
    public GameObject bigFood;
    //Border
    private Transform border_Top;
    private Transform border_Bottom;
    private Transform border_Left;
    private Transform border_Right;

    public static bool ate;

    private int CountFood = 0;

    // Use this for initialization
    void Start()
    {
        ate = false;
        //spawn food every 4 seconds, starting in 3
        border_Top = GameObject.Find("Top_Border").transform;
        border_Bottom = GameObject.Find("Bottom_Border").transform;
        border_Left = GameObject.Find("Left_Border").transform;
        border_Right = GameObject.Find("Right_Border").transform;
        Spawn(smallFood);
        CountFood = 1;
    }
    void Update()
    {
        if (ate)
        {
            if (CountFood == 5)
            {
                Spawn(bigFood);
                CountFood = 0;
            }
            else
            {
                Spawn(smallFood);
                CountFood++;
            }
        }
    }

    void Spawn(GameObject food)
    {

        Vector3 spawnPos;


        //        // x position between left & right border
        //        float x = Mathf.Round(Random.Range(border_Left.position.x + 6f, border_Right.position.x - 6f)) + 0.5f;

        //        //y position between top & bottom border
        //        float z = Mathf.Round(Random.Range(border_Top.position.z - 6f, border_Bottom.position.z + 6f)) + 0.5f;
        //=======
        //        do
        //        {
        // x position between left & right border
        float x = Mathf.Round(Random.Range(border_Left.position.x + 6f, border_Right.position.x - 6f)) + 0.5f;

        //y position between top & bottom border
        float z = Mathf.Round(Random.Range(border_Top.position.z - 6f, border_Bottom.position.z + 6f)) + 0.5f;

        spawnPos = new Vector3(x, 0.5f, z);

        //} while (IsRock(spawnPos, CreatEnvironment.listRock));



        //Instantiate the food at (x, y)
        if (!IsRock(spawnPos, CreatEnvironment.listRock))
        {
            Instantiate(food, spawnPos, Quaternion.identity);
            ate = false;
        }
        else return;
    }

    bool IsRock(Vector3 pos, List<Vector3> listRock)
    {
        foreach (var posRock in listRock)
        {
            if (pos == posRock)
                return true;
        }

        return false;
    }



}
