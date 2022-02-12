using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_ : MonoBehaviour
{
    public KeyCode JumpKey = KeyCode.Z;
    public float baseJump = 40;
    public float baseAdditiveJump = 40;
    public float jumpFactor = 0.8f;

    float additiveJump = 0;
    bool jumpKeyHold = false;
    bool grounded = false;


    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(JumpKey))
        {
            Jump();
        }
        else
        {
            jumpKeyHold = false;
        }

        var direction = 0;
        if (Input.GetKey(KeyCode.A))
            direction--;
        if (Input.GetKey(KeyCode.D))
            direction++;

        Move(direction);

    }

    void Move(int direction)
    {
        if (direction == 0)
            return;

        rb.AddForce(Vector2.right * direction * 10);
    }

    void Jump()
    {

        if (grounded)
        {
            rb.AddForce(Vector2.up * baseJump);
            additiveJump = baseAdditiveJump;
            jumpKeyHold = true;
        }
        else if (jumpKeyHold)
        {
            if (additiveJump < 1)
            {
                jumpKeyHold = false;
                return;
            }

            rb.AddForce(Vector2.up * additiveJump);
            additiveJump *= jumpFactor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var surfaceAngle = Vector2.Angle(collision.GetContact(0).normal, Vector2.up);
        if (surfaceAngle < 30)
            grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
