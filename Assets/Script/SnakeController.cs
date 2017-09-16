using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour {

	// Use this for initialization
    public Vector2 dir;
    public SpriteRenderer[] sprites;
	void Start () {
		dir = Vector2.right;
        sprites = GetComponentsInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
            //StartCoroutine(RotateMe(-Vector3.back*90, 1f));
        }
        
	}
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
