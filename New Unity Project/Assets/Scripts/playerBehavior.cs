using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{
    private Rigidbody2D rigBody;
    private Animator animator;
    public float maxSpeed = 10f;
    public float jumpForce = 900f;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;
    public float move;

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    // Use this for initialization
    void Start()
    {

        animator = GetComponent<Animator>();
        animator.SetInteger("State", 0);
        rigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        move = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        if (IsGrounded())
        {
            animator.SetInteger("State", 1);
            animator.speed = Mathf.Abs(rigBody.velocity.x/5);
            if (rigBody.velocity==Vector2.zero)
                animator.SetInteger("State", 0);
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                rigBody.AddForce(new Vector2(0f, jumpForce));
        }
        else
        {
            animator.SetInteger("State", 2);
        }
        rigBody.velocity = new Vector2(move * maxSpeed, rigBody.velocity.y);

        if (rigBody.velocity.x > 0)
            transform.localScale = new Vector2(1, 1);
        if (rigBody.velocity.x < 0)
            transform.localScale = new Vector2(-1, 1);

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.R))
        {
            //Application.LoadLevel(Application.loadedLevel);
        }


    }


}