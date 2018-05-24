using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerBehavior : MonoBehaviour
{
    private Rigidbody2D rigBody;
    private Animator animator;
    public float maxSpeed = 10f;
    private float jumpForce = 980f;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;
    public float move;
    private int health = 1;
    private AudioSource[] audioSources;

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
        audioSources =GameObject.Find("AudioObject").GetComponents<AudioSource>();
        animator = GetComponent<Animator>();
        animator.SetInteger("State", 0);
        rigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        move = Input.GetAxis("Horizontal");
        //print(move);
        //move = CrossPlatformInputManager.GetAxis("Horizontal");
    }
    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void TakeDamage()
    {
        health -= 1;
        if (health == 0)
        {
            Death();
        }
    }
    bool IsControlJump()
    {

        return (CrossPlatformInputManager.GetButtonDown("Jump") || (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)));
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            if (col.GetType().ToString() != "UnityEngine.BoxCollider2D")
            {
                if (IsGrounded())
                {
                    TakeDamage();
                }
                else
                {
                    //Destroy(col.gameObject);
                    col.gameObject.SendMessage("TakeDamage");
                    Jump();
                }

            }
            else
            {
                if (IsGrounded())
                {
                    TakeDamage();
                }
            }

        }
        if (col.gameObject.tag == "Border")
        {
            if(col.contacts[0].point.y<=-1)
            Death();
        }
        if (col.gameObject.tag == "LevelEnd")
        {
            Death();
        }
    }
    void Jump()
    {
        
        rigBody.AddForce(new Vector2(0f, jumpForce));
    }
    void Update()
    {
            move = GameObject.Find("MoveSlider").GetComponent<Slider>().value;
            if (IsGrounded())
            {
                animator.SetInteger("State", 1);
                animator.speed = Mathf.Abs(rigBody.velocity.x / 5);
                if (rigBody.velocity == Vector2.zero)
                    animator.SetInteger("State", 0);

                if (IsControlJump())
                {
                    audioSources[0].Play();
                    Jump();
                }
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

        }
    


}