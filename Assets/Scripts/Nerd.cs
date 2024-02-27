using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nerd : MonoBehaviour
    {
    public static int score;

    Rigidbody2D rb;
    CircleCollider2D ballCircleCollider2D;

    public float speedX = 15f, speedY = 15f;

    void Start ( )
    {
        rb = GetComponent<Rigidbody2D>();
        ballCircleCollider2D = GetComponent<CircleCollider2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        Invoke("ballStart", 3);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            ballStart();
        }
    }

    void ballStart() {
        if(rb.velocity == Vector2.zero)
        {
            ballCircleCollider2D.enabled = true;
            transform.SetParent (null);
            rb.velocity = new Vector2(speedX, speedY);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        rb.velocity = new Vector2(rb.velocity.x<0?-speedX:speedX, rb.velocity.y<0?-speedY:speedY);
        if (col.gameObject.tag == "Bricks")
        {
            Destroy(col.gameObject);
            score += 1;
        }
    }
}