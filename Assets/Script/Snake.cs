using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Sprite[] headSprites;
    public float speed = 4f;
    public float distance = 9.0f;
    [SerializeField]
    public GameObject tailPrefab;

    Vector2 dir = Vector2.right;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = this.transform.position;

        Sprite sprite = this.GetComponent<SpriteRenderer>().sprite;
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sprite = headSprites[0];
            dir = Vector2.right;
            newPos.x += distance;
            transform.position = Vector3.Lerp(this.transform.position, newPos, Time.deltaTime / 10);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            sprite = headSprites[1];
            dir = -Vector2.up;    // '-up' means 'down'
            newPos.y -= distance;
            transform.position = Vector3.Lerp(this.transform.position, newPos, Time.deltaTime / 10);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            sprite = headSprites[2];
            dir = -Vector2.right; // '-right' means 'left'
            newPos.x -= distance;
            transform.position = Vector3.Lerp(this.transform.position, newPos, Time.deltaTime / 10);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            sprite = headSprites[3];
            dir = Vector2.up;
            newPos.y += distance;
            transform.position = Vector3.Lerp(this.transform.position, newPos, Time.deltaTime / 10);
            
        }
       // transform.Translate(dir * Time.deltaTime * speed);

    }


    //ĐI TỪ TƯỜNG BÊN NÀY SANG BÊN KIA
   
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    Vector3 newPos = new Vector3();
    //    switch (col.gameObject.name)
    //    {
    //        case "Right_Border":
    //            newPos = GameObject.Find("Left_Border").transform.position;
    //            newPos.y = this.transform.position.y;
    //            transform.position = newPos;
    //            transform.Translate(0.5f, 0, 0);
    //            break;
    //        case "Left_Border":
    //            newPos = GameObject.Find("Right_Border").transform.position;
    //            newPos.y = this.transform.position.y;
    //            transform.position = newPos;
    //            transform.Translate(-0.5f, 0, 0);
    //            break;
    //        case "Top_Border":
    //            newPos = GameObject.Find("Bottom_Border").transform.position;
    //            newPos.x = this.transform.position.x;
    //            transform.position = newPos;
    //            transform.Translate(0, 0.5f, 0);
    //            break;
    //        case "Bottom_Border":
    //            newPos = GameObject.Find("Top_Border").transform.position;
    //            newPos.x = this.transform.position.x;
    //            transform.position = newPos;
    //            transform.Translate(0, -0.5f, 0);
    //            break;
    //        case "Food":
    //            Vector3 pos = this.transform.position;
    //            pos.x -= 1f;
    //            Instantiate(tailPrefab, pos, Quaternion.identity, this.transform);
    //            break;
    //    }

    //}

    //IEnumerator RotateMe(Vector3 byAngles, float inTime)
    //{
    //    var fromAngle = transform.rotation;
    //    var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
    //    for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
    //    {
    //        transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
    //        yield return null;
    //    }
    //}

    
}
