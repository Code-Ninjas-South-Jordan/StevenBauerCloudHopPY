using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    // Jump commands/code are in here
    Rigidbody2D rigidbody;
    float jumpForce = 15;
    public bool canJump;
    
    Rigidbody2D rigidBody;
    Animator anim;

    public float speed;

    float masterSpeed;
    bool canMoveL, canMoveR;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        masterSpeed = speed;        
    }

    void Update()
    {
        if(rigidbody.velocity.y > -.01 && rigidbody.velocity.y < .01)
        {
            canJump = true;
        } else
        {
            canJump = false;
        }

        if(Input.GetButtonDown("Jump") && canJump)
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        //get right/left input information
        float horizontal = Input.GetAxis("Horizontal");

        if(horizontal < 0 && transform.position.x >= -6.5f){
            transform.position += new Vector3(horizontal, 0) * Time.deltaTime * speed;
        }
        if(horizontal > 0 && transform.position.x <= 6.5f){
            transform.position += new Vector3(horizontal, 0) * Time.deltaTime * speed;
        }

        //get vertical velocity
        float verticalMovement = rigidBody.velocity.y;
        //if player is in the air, decrease speed
        if (verticalMovement != 0)
        {
            speed = masterSpeed / 1.8f;

            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", true);
        }
        else
        {
            speed = masterSpeed;

            anim.SetBool("isIdle", true);
            anim.SetBool("isJumping", false); 
        }



        //move player left and right according to user input and speed
    }
}

