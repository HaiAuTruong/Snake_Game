using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Touch : MonoBehaviour {

    //ĐI TỪ TƯỜNG BÊN NÀY SANG BÊN KIA

    void OnTriggerEnter2D(Collider2D col)
    {
        Vector3 newPos = new Vector3();
        switch (col.gameObject.name)
        {
            case "Right_Border":
                newPos = GameObject.Find("Left_Border").transform.position;
                newPos.y = this.transform.position.y;
                transform.position = newPos;
                transform.Translate(1f, 0, 0);
                break;
            case "Left_Border":
                newPos = GameObject.Find("Right_Border").transform.position;
                newPos.y = this.transform.position.y;
                transform.position = newPos;
                transform.Translate(-1f, 0, 0);
                break;
            case "Top_Border":
                newPos = GameObject.Find("Bottom_Border").transform.position;
                newPos.x = this.transform.position.x;
                transform.position = newPos;
                transform.Translate(0, 1f, 0);
                break;
            case "Bottom_Border":
                newPos = GameObject.Find("Top_Border").transform.position;
                newPos.x = this.transform.position.x;
                transform.position = newPos;
                transform.Translate(0, -1f, 0);
                break;
            
        }

    }
}
