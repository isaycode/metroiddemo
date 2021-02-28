using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class jump : MonoBehaviour
{
    //force
    //apply force
    //upwardforce/gravity rb.velocity=new vector2(set parameters)
    [Header("j_detail")]
    public float jumpf;
    public float j_time;
    private float jumptimec;
    private bool stopjumping;


    [Header("ground check")]
    [SerializeField] private Transform point;
    [SerializeField] private float radCircle;
    [SerializeField] private LayerMask Groundcheck;
    public bool grounded;


    [Header("component")]
    private Rigidbody2D rb ;
    private Animator anim;



    private void Start()
    {
    	rb=GetComponent<Rigidbody2D>();
    	anim=GetComponent<Animator>(); 
    	jumptimec= j_time;
    }


    private void Update()

    {
    		//grounded
    	grounded = Physics2D.OverlapCircle(point.position,radCircle,Groundcheck);
    	//press space to jump
    	if (grounded)
    	{
    		jumptimec=j_time;
    		anim.ResetTrigger("up");
    		anim.SetBool("landing", false);
    	}
    	
	  	

       // press the jump button

    	if (Input.GetButtonDown("Jump") && grounded )
    	{
    		//jumping
    		rb.velocity=new Vector2(rb.velocity.x, jumpf);
    		stopjumping=false;
    		//tell the animator to play jump
    		anim.SetTrigger("up");
    	}

    	//to keep jumping while holding jump button
    	if(Input.GetButton("Jump") && !stopjumping && (jumptimec > 0))
    	{
    		//keep jumping
    		rb.velocity=new Vector2(rb.velocity.x, jumpf);
    		jumptimec-=Time.deltaTime;
    		anim.SetTrigger("up");

    	}

    	 //if we release the jump button
   		if (Input.GetButtonUp("Jump"))
    	{
    		jumptimec=0;
    		stopjumping=true;
    		anim.SetBool("landing", true);
    		anim.ResetTrigger("up");
    	}


    	if (rb.velocity.y < 0)
    	{
    	  anim.SetBool("landing", true);
    	}

    }

    
   	private void OnDrawGizmos()
    {
   		Gizmos.DrawSphere(point.position,radCircle);
    }



   
}
