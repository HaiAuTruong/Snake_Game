using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDirection : MonoBehaviour {

    public float smooth = 5f;

    public static bool isTurning = false;

    public static Vector3 beforeTurningPos;

    public static Quaternion targetRotation;

    private string Direction;

	void Start () {
        targetRotation = transform.rotation;
        Direction = "Up";
 
	}
	
	
	void Update () {

        //GET INPUT KEY TO ROTATE
   
        if (Input.GetKey(KeyCode.RightArrow) && Direction != "Right" && Direction != "Left")
        {
            if (Direction == "Up")
            {
              //  this.transform.DetachChildren();
                Direction = "Right"; 
                targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
                isTurning = true;
            }
            else if (Direction == "Down")
            {
              //  this.transform.DetachChildren();
                Direction = "Right";
                targetRotation *= Quaternion.AngleAxis(-90, Vector3.up);
                isTurning = true;
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Direction != "Right" && Direction != "Left")
        {

            if (Direction == "Up")
            {
              //  this.transform.DetachChildren();
                Direction = "Left";
                targetRotation *= Quaternion.AngleAxis(-90, Vector3.up);
                isTurning = true;
            }
            else if (Direction == "Down")
            {
                //this.transform.DetachChildren();
                Direction = "Left";
                targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
                isTurning = true;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Direction != "Up" && Direction != "Down")
        {
            if (Direction == "Right")
            {
               // this.transform.DetachChildren();
                Direction = "Up";
                targetRotation *= Quaternion.AngleAxis(-90, Vector3.up);
                isTurning = true;
            }
            else if (Direction == "Left")
            {
               // this.transform.DetachChildren();
                Direction = "Up";
                targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
                isTurning = true;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Direction != "Up" && Direction != "Down")
        {
            if (Direction == "Right")
            {
              //  this.transform.DetachChildren();
                Direction = "Down";
                targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
                isTurning = true;
            }
            else if (Direction == "Left")
            {
               // this.transform.DetachChildren();
                Direction = "Down";
                targetRotation *= Quaternion.AngleAxis(-90, Vector3.up);
                isTurning = true;
            }
        }

        
        //ROTATE THE SNAKE AFTER INPUT
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);

        //FIX THE POSITION AFTER ROTATE

        Vector3 currentPos = this.transform.position;
        if (currentPos.x * 10 % 10 != 5 || currentPos.z * 10 % 10 != 5)
        {
            Vector3 fixPos = new Vector3();
            fixPos.x = Mathf.Floor(currentPos.x) + 0.5f;
            fixPos.y = 0.5f;
            fixPos.z = Mathf.Floor(currentPos.z) + 0.5f;
            this.transform.position = fixPos;
        }


        
	}
   
}
 