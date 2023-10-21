using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Interactions;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float jumpingPower = 25f;
    private Rigidbody2D rigidbody;
    public float speed = 5f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        isGrounded = false; // Initially, the player is not grounded.
    }

    private void Update()
    {

        float clampedSpeed = Mathf.Clamp(horizontal * speed, -speed, speed);
        rigidbody.velocity = new Vector2(clampedSpeed, rigidbody.velocity.y);
    } 

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpingPower);
            isGrounded = false; // Player is no longer grounded after jumping.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if ((groundLayer & 1 << collision.gameObject.layer) != 0)
            {
                isGrounded = true;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        rigidbody.velocity = new Vector2(Mathf.Clamp(rigidbody.velocity.x, -0.1f, 0.1f), rigidbody.velocity.y);
    }
}
