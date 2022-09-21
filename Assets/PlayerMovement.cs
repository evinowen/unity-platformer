using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float WalkForce;
    public float WalkVelocity;
    public float JumpForce;

    private Rigidbody2D Body;
    private PlayerInput Input;
    private bool FacingRight = true;

    void Start()
    {
        this.Body = GetComponent<Rigidbody2D>();
        this.Input = GetComponent<PlayerInput>();
    }

    void Update ()
    {
        this.MoveInput();

        if (this.Body.position.y < -20) {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void MoveInput ()
    {
        Vector2 Move = this.Input.actions["Move"].ReadValue<Vector2>();

        float MoveHoriontal = Move.x;

        if (MoveHoriontal > 0 && !this.FacingRight)
        {
            this.Flip();
        }
        else if (MoveHoriontal < 0 && this.FacingRight)
        {
            this.Flip();
        }

        float WalkMagnitude = this.Body.velocity.magnitude;
        float WalkPower = WalkMagnitude > 0.01f ? (WalkVelocity - WalkMagnitude) / WalkVelocity : 1.0f;

        if (WalkPower > 0) {
            this.Body.AddForce(Vector2.right * MoveHoriontal * WalkForce * WalkPower);
        }

        float MoveVertical = Move.y;

        if (MoveVertical > 0) {
            if (Mathf.Abs(this.Body.velocity.y) <= 0.0001) {
                this.Body.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            }
        }
    }

    void Flip()
    {
        this.FacingRight = !this.FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
