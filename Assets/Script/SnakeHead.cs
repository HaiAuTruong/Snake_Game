using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour {
    Vector2 direction;
	// Use this for initialization
	void Start () {
		direction =  GameObject.Find("Snake").GetComponent<SnakeController>().dir;
	}
	
	// Update is called once per frame
	void Update () {
        direction = GameObject.Find("Snake").GetComponent<SnakeController>().dir;
	}
    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }
}
