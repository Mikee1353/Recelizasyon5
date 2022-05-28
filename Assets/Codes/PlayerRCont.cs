using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRCont : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 5;
    [SerializeField] CircleCollider2D groundCheck;
    [SerializeField] private LayerMask GroundMask;
    Rigidbody2D rb;
    public bool isFacingRight;
    Animator anim;

    public float fallMultiplier = 2.5f;
    void Start()
    {
        groundCheck = GetComponentInChildren<CircleCollider2D>(); 
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        var horiz = rb.velocity.y;
        
        //Movement
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(-movement, 0, 0) * Time.deltaTime * speed;

        //Jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = Vector2.down * jumpForce;


        }

        //Flip
        if ((movement < 0 && isFacingRight) || (movement > 0 && !isFacingRight))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }

        //BetterJump
        if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.down * Physics2D.gravity.y * (fallMultiplier -1) * Time.deltaTime;
        }
        else if (rb.velocity.y < 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.down * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        //WalkAnimation
        anim.SetFloat("Speed", Mathf.Abs(movement));

        //JumpAnimation
        if (horiz < 0)
        {
            anim.SetBool("Jumping", true);
            anim.SetBool("Falling", false);
        }
        else if (horiz > 0)
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Jumping", false);
        }

    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(groundCheck.bounds.center, groundCheck.bounds.size, 0, Vector2.down, 0f, GroundMask);
    }



}
