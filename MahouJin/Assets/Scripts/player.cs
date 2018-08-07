using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    //prepare my rigidbody object
    Rigidbody2D myrigidbody;
	// Use this for initialization
    float X = 3.55f;
    float Y = 2.0f;

	void Start () {
        //Fetch the RigidBody from the GameObject
        myrigidbody = GetComponent<Rigidbody2D>();
        //float x = Random.Range(-1.0f,1.0f);//0to1.0
        //float y =  (float)System.Math.Sqrt(1 - System.Math.Pow(x, 2) );
        myrigidbody.velocity = new Vector2(4, 0) ;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0){
             //Touch touch = Input.GetTouch(0);
             //Vector2 vec =touch.position;
             //vec = Camera.main.ScreenToWorldPoint (vec);
             //transform.position = vec* new Vector2(1,0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myrigidbody.velocity = Vector2.right * 5;
        }
        if (Input.GetKey(KeyCode.LeftArrow) )
        {
            myrigidbody.velocity = Vector2.left * 5;
        }
        if(transform.position.x>X||transform.position.x<-X){
            myrigidbody.velocity *= new Vector2(-1,1);
        }
        if (transform.position.y > Y || transform.position.y < -Y)
        {
            myrigidbody.velocity *= new Vector2(1, -1);
        }

        
		
	}

    public void whenbuttonpushed(int number){
        Vector2 vec =new Vector2(0,0);
        myrigidbody.velocity *= new Vector2(0,0);
    }
	//FixedUpdate is called once per phisically movements from calculation
	void FixedUpdate()
	{

	}
	public void OnMouseDown ()
	{
        
	}
}
