using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    float input;
    float speed = 10f;
    Vector2 targetVelocity;
    float jumpForce = 12f;
    bool isJumped;
    bool isGrounded = true;
    float lastTimeShoot;
    bool isAlive;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastTimeShoot = Time.time;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (input > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (input < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            isJumped = true;
        }
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            targetVelocity = new Vector2(input * speed, rb.velocity.y);

            rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.fixedDeltaTime * 10f);
            if (isGrounded && isJumped)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumped = false;
            }
        }

    }
}
