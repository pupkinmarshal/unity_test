using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    private Rigidbody2D rigBody;
     float maxSpeed = 10f;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;
    public float move;
    private AudioSource[] audioSources;
    // Use this for initialization

    bool IsGrounded(float distance)
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        //float distance = 0.6f;


        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
    void TakeDamage()
    {
        audioSources[1].Play();
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy")
        {
            //Vector2 collisionPoint = col.contacts[0].point;
            
            if (col.otherCollider.GetType().ToString() == "UnityEngine.BoxCollider2D")
                move *= -1;
        }
    }
    void SetActive()
    {
        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour c in comps)
        {
            c.enabled = true;
        }
    }
    void SetNonActive()
    {
        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour c in comps)
        {
            c.enabled = false;
        }
    }
    void Start()
    {
        SetNonActive();
        audioSources = GameObject.Find("AudioObject").GetComponents<AudioSource>();
        rigBody = GetComponent<Rigidbody2D>();
        move = -1;

    }


    // Update is called once per frame
    void Update()
    {

            rigBody.velocity = new Vector2(move * maxSpeed / 3, rigBody.velocity.y);

            // if (rigBody.velocity.x == 0)


            if (rigBody.velocity.x > 0)
                transform.localScale = new Vector2(1, 1);
            if (rigBody.velocity.x < 0)
                transform.localScale = new Vector2(-1, 1);
        

    }
}
