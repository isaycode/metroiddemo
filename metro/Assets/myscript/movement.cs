using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class movement : MonoBehaviour
{
  	//for animations and physics
  	private Rigidbody2D rb2d;
  	private Animator    anim;
  	// variables
  	public float speed=2.0f;
  	public float horizmovement; //=1, -1, 0

  	private bool facingright=true;
    
    private void Start()
    {
    	//define object on pla
    rb2d=GetComponent<Rigidbody2D>();
    anim=GetComponent<Animator>();    
    }

    // handles input for physics
    private void Update()
    {
        //check if the input button is pressed
        horizmovement=Input.GetAxis("Horizontal");
       
    }

    //handles run
    private void FixedUpdate()
    {
        //move the character handles physics
        rb2d.velocity= new Vector2(horizmovement *speed,rb2d.velocity.y);
        flip(horizmovement);
        anim.SetFloat("mag", Mathf.Abs(horizmovement));

    }


    private void flip(float horizontal)
    {
    	//facing left and right flip
    	if (horizontal > 0 && !facingright || horizontal < 0 && facingright)
    	{
    		facingright=!facingright;
    		Vector3 theScale= transform.localScale;
    		theScale.x *= -1;
    		transform.localScale=theScale;

    	}
    }

    }
