using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed;
    public float JumpForce;

    private Vector2 moveInput;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;
    private void Start()
    {
        
    }
    private void Update()
    {

        //Horizontal Movement only since we only want the character to move in the x direction
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        rb.velocity = new Vector3(moveInput.x * movespeed, rb.velocity.y, 0);

        //check if we're on the ground
        RaycastHit hit;
        RaycastHit2D hitInfo = Physics2D.Raycast(groundPoint.position, Vector2.down, 0.3f, whatIsGround);
        if (hitInfo){
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
        //if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        //{
        //    isGrounded = true;

        //}
        //else
        //{
        //    isGrounded = false;
        //}

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity += new Vector2(0f, JumpForce);
        }

    }
}
