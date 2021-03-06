﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatEnvironment : MonoBehaviour
{
    public GameObject Rock1;
    public GameObject Rock2;
    public GameObject Rock3;
    public GameObject Rock4;
    public GameObject Rock5;
    static int n = 12;
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
        Instantiate(Rock1, Pos, Quaternion.identity, this.transform);
        Debug.Log("rock");
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
                if(i % 5 == 1)
                    Instantiate(Rock1, Pos, Quaternion.identity, this.transform);
                else if(i % 5 == 2)
                    Instantiate(Rock2, Pos, Quaternion.identity, this.transform);
                else if(i % 5 == 3)
                    Instantiate(Rock3, Pos, Quaternion.identity, this.transform);
                else if(i % 5 == 4)
                    Instantiate(Rock4, Pos, Quaternion.identity, this.transform);
                else
                    Instantiate(Rock5, Pos, Quaternion.identity, this.transform);
  
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
