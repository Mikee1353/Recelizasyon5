using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNCont : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 5;
    [SerializeField] CircleCollider2D groundCheck;
    [SerializeField] private LayerMask GroundMask;
    Rigidbody2D rb;
    public bool isFacingLeft = true;
    SpriteRenderer sr;

    public float fallMultiplier = 2.5f;
    void Start()
    {
        groundCheck = GetComponentInChildren<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Movement
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        //Jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        //Flip
        if ((movement > 0 && isFacingLeft) || (movement < 0 && !isFacingLeft))
        {
            isFacingLeft = !isFacingLeft;
            transform.Rotate(new Vector3(0, 180, 0));
        }


        //BetterJump
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }



    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(groundCheck.bounds.center, groundCheck.bounds.size, 0, Vector2.up, 0f, GroundMask);
    }

}
