using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour {

    private bool paused;

    private float time;

    private GameObject head;
	// Use this for initialization
	void Start () {
        head = GameObject.Find("Head");
        SnakeMove_Ver2 snakeScript =  head.GetComponent<SnakeMove_Ver2>();
        time = snakeScript.time;
        
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.parent == null)
        {
            if (paused)
                return;
            transform.position += transform.forward * 1.0f;
            
            StartCoroutine(Pause());
        }
	}
    private IEnumerator Pause()
    {
        paused = true;
        yield return new WaitForSeconds(time);
        paused = false;
    }
    void OnTriggerEnter(Collider col)
    {
       
        Vector3 newPos = new Vector3();
        switch (col.gameObject.name)
        {
            case "Right_Border":
            case "Left_Border":
            case "Top_Border":
            case "Bottom_Border":
                newPos = head.transform.position - (getBodyPos() + 1) * head.transform.forward;               
                transform.position = newPos;
                this.transform.parent = head.transform;
                break;
         
        }

    }
    int getBodyPos()
    {
        for (int i=0;i < SnakeMove_Ver2.bodyPart.Count;i++)
        {
            if (this.gameObject.transform == SnakeMove_Ver2.bodyPart[i])
                return i;
        }
        return -1;
    }
}
