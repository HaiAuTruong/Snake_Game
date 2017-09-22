using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatEnvironment : MonoBehaviour
{
    public GameObject Rock;
    static int n = 10;
    public static List<Vector3> listRock = new List<Vector3>(n);
    private int defaultDistance = 30;
    private Transform border_Top;
    private Transform border_Bottom;
    private Transform border_Left;
    private Transform border_Right;
   

    // Use this for initialization
    void Start() {
        border_Top = GameObject.Find("Top_Border").transform;
        border_Bottom = GameObject.Find("Bottom_Border").transform;
        border_Left = GameObject.Find("Left_Border").transform;
        border_Right = GameObject.Find("Right_Border").transform;
        CreatEnviro();
	}

    // Update is called once per frame
    void Update()
    {

    }

    void CreatEnviro()
    {
        Vector3 Pos = randomRock();
        listRock.Add(Pos);
        Instantiate(Rock, Pos, Quaternion.identity, this.transform);

        for(int i = 1; i < n; i++)
        {
            Vector3 posTemp = randomRock();
            if (checkDistance(listRock, Pos))
            {
                listRock.Add(posTemp);
                Instantiate(Rock, posTemp, Quaternion.identity, this.transform);
            }
            else
                i--;
        }
    }

    Vector3 randomRock()
    {
        //x position between left & right border
        float  x = Random.Range(border_Left.position.x + 6f, border_Right.position.x - 6f);

        //z position between top & bottom border
        float z = Random.Range(border_Top.position.z - 6f, border_Bottom.position.z + 6f);

        Vector3 Pos = new Vector3(x, 0.5f, z);

        return Pos;
    }

    bool checkDistance(List<Vector3> listRock, Vector3 Pos)
    {
        foreach(var posRock in listRock)
        {
            if (Vector3.Distance(Pos, posRock) < defaultDistance)
                return false;
        }
            return true;
    }
}
