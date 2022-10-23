using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isPlayer1 = true;
    public Animator animator;
    public Rigidbody2D rb;
    public float movespeed;
    public float JumpForce;

    private Vector2 moveInput;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    public Transform attackPoint;
    private bool isGrounded;

    private void Start()
    {
        
    }
    private void Update()
    {

        //Horizontal Movement only since we only want the character to move in the x direction
        if(isPlayer1 == true)
        {
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");
        } else
        {
            moveInput.x = Input.GetAxis("Horizontal2");
            moveInput.y = Input.GetAxis("Vertical2");
        }
        moveInput.Normalize();

        rb.velocity = new Vector3(moveInput.x * movespeed, rb.velocity.y, 0);

        // set animator values
        animator.SetFloat("XVelocity", Mathf.Abs(moveInput.x * movespeed));

        if ((isPlayer1 && Input.GetKeyDown(KeyCode.V)) || (!isPlayer1 && Input.GetKeyDown(KeyCode.RightControl)))
        {
            Attack();
        }

        // flip object when traveling to the left
        if (moveInput.x * movespeed < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (moveInput.x * movespeed > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //check if we're on the ground
        RaycastHit2D hitInfo = Physics2D.Raycast(groundPoint.position, Vector2.down, 0.3f, whatIsGround);
        if (hitInfo){
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
        // set animator value
        animator.SetBool("isGrounded", isGrounded);

        // check for jump
        if(isGrounded && ( (isPlayer1 && Input.GetKeyDown(KeyCode.W)) || (!isPlayer1 && Input.GetKeyDown(KeyCode.UpArrow)) ))
        {
            rb.velocity += new Vector2(0f, JumpForce);
        }

    }

    void Attack ()
    {
        // play animation
        animator.SetTrigger("Attack");
        // detect enemy in range
        Collider2D[] hitStuff = Physics2D.OverlapCircleAll(attackPoint.position, 0.7f);
        foreach(Collider2D hitThing in hitStuff)
        {
            if ((isPlayer1 && hitThing.name == "Player2Sprite/Collision") || (!isPlayer1 && hitThing.name == "Player1Sprite/Collision"))
            {
                DoDamageTo(hitThing.GetComponentInParent<DamageAndHealth>());
                break;
            }
        }
        void DoDamageTo(DamageAndHealth victim)
        {
            victim.TakeDamage(20);
        }
    }
}
