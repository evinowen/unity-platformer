using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.moveDirection = Input.GetAxis("Horizontal");

        if (this.moveDirection > 0 && !facingRight)
        {
            this.Flip();
        }
        else if (moveDirection < 0 && facingRight)
        {
            this.Flip();
        }

        this.rb.velocity = new Vector2(this.moveDirection * this.moveSpeed, this.rb.velocity.y);

        if (Input.GetAxis("Jump") > 0)
        {
            if (this.rb.velocity.y > -0.01 && this.rb.velocity.y < 0.01)
            {
                this.rb.velocity = new Vector2(this.rb.velocity.x, 8);
            }
        }
    }

    void Flip()
    {
        this.facingRight = !this.facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
