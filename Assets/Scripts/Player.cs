using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;
    float movementDirection;
    bool isJumping = false;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Debug.Log(rigidbody.velocity);
    }
    void MovementDirection()
    {
        movementDirection = Input.GetAxisRaw("Horizontal");
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.UpArrow) && isJumping != true)
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }
    void Move()
    {
        if (Mathf.Abs(rigidbody.velocity.x) < 7)
        {
            rigidbody.AddForce(new Vector2(movementDirection * movementSpeed, 0));
        }
    }
    void Movement()
    {
        MovementDirection();
        Jump();
        Move();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
