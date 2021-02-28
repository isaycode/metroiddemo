using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]


public class attack : MonoBehaviour
{
   

   [Header("component")]
    private Rigidbody2D rb ;
    private Animator anim;


    private void Start()
    {
    	//rb=GetComponent<Rigidbody2D>();
    	anim=GetComponent<Animator>(); 
    	
    }


    private void Update()
    {

    	if (Input.GetMouseButtonDown(0) )
    	{
    		anim.SetBool("attack", true);
    			
    	}

    	//to keep jumping while holding jump button
    	

    	 //if we release the jump button
   		if (Input.GetMouseButtonUp(0))
    	{
    		anim.SetBool("attack", false);
    		
    	}


    }
}

