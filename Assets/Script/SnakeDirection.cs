using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDirection : MonoBehaviour {

    public float smooth = 1f;
  
    private Quaternion targetRotation;
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
                
                Direction = "Right"; 
                targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
                
            }
            else if (Direction == "Down")
            {
                
                Direction = "Right";
                targetRotation *= Quaternion.AngleAxis(-90, Vector3.up);
               
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Direction != "Right" && Direction != "Left")
        {

            if (Direction == "Up")
            {
                
                Direction = "Left";
                targetRotation *= Quaternion.AngleAxis(-90, Vector3.up);
                
            }
            else if (Direction == "Down")
            {
                
                Direction = "Left";
                targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
                
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Direction != "Up" && Direction != "Down")
        {
            if (Direction == "Right")
            {
                
                Direction = "Up";
                targetRotation *= Quaternion.AngleAxis(-90, Vector3.up);
                
            }
            else if (Direction == "Left")
            {
                
                Direction = "Up";
                targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
                
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Direction != "Up" && Direction != "Down")
        {
            if (Direction == "Right")
            {
                
                Direction = "Down";
                targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
                
            }
            else if (Direction == "Left")
            {
                
                Direction = "Down";
                targetRotation *= Quaternion.AngleAxis(-90, Vector3.up);
                
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
