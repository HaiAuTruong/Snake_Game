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

    private float defaultDistance = 3f;
    private bool isAppear;
    // Use this for initialization
    void Start()
    {
        ate = false;
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

                GameObject createdFood = Spawn(bigFood);
                CountFood = 0;
                StartCoroutine(Appear(createdFood));
            }
            else
            {
                Spawn(smallFood);
                CountFood++;
            }
        }
    }

    GameObject Spawn(GameObject food)
    {

        Vector3 spawnPos;
        float x = Mathf.Round(Random.Range(border_Left.position.x + 6f, border_Right.position.x - 6f)) + 0.5f;

        float z = Mathf.Round(Random.Range(border_Top.position.z - 10f, border_Bottom.position.z + 6f)) + 0.5f;

        spawnPos = new Vector3(x, 0.5f, z);
        if (!IsRock(spawnPos, CreatEnvironment.listRock))
        {
           GameObject foodCreated = Instantiate(food, spawnPos, Quaternion.identity,this.transform) as GameObject;
            ate = false;
            return foodCreated;
        }
        else return null;
    }

    bool IsRock(Vector3 pos, List<Vector3> listRock)
    {
        foreach (var posRock in listRock)
        {
            if (Vector3.Distance(pos, posRock) < defaultDistance)
                return true;
        }

        return false;
    }

    private IEnumerator Appear(GameObject bigFood)
    {
       // isAppear = true;
        yield return new WaitForSeconds(3);
       // isAppear = false;
        Destroy(bigFood);
        ate = true;
    }
}
