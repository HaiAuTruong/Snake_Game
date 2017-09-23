using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatEnvironment : MonoBehaviour
{
    public GameObject Rock;
    static int n = 5;
    public static List<Vector3> listRock = new List<Vector3>(n);
    private float defaultDistance = 10f;
    private Transform border_Top;
    private Transform border_Bottom;
    private Transform border_Left;
    private Transform border_Right;
    private int createdRock = 0;

    // Use this for initialization
    void Start() {
        border_Top = GameObject.Find("Top_Border").transform;
        border_Bottom = GameObject.Find("Bottom_Border").transform;
        border_Left = GameObject.Find("Left_Border").transform;
        border_Right = GameObject.Find("Right_Border").transform;
        CreatEnviro();
	}

    void CreatEnviro()
    {
        //Khoi tao cuc da dau` tien
        Vector3 Pos = randomRock();
        listRock.Add(Pos);
        Instantiate(Rock, Pos, Quaternion.identity, this.transform);
        createdRock++;
        
        //Kiem tra tu 0 -> createdRock thoi, kiem tra het listRock thi no null day :v
        int i=1;
        while (i<n)
        {
            Pos = randomRock();
            bool temp = true;
            for (int j = 0; j < createdRock; j++)
            {
                if (Vector3.Distance(Pos, listRock[j]) < defaultDistance)
                {
                    temp = false;
                    break;
                }
            }
            if (temp)
            {
                listRock.Add(Pos);
                Instantiate(Rock, Pos, Quaternion.identity, this.transform);
                createdRock++;
                i++;
            }
            
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

}
