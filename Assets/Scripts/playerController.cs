using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    //Movement Variable
    public float maxspeed;
    public float moveInput;
    public float moveSpeed;
    public float acceleration;
    public float decceleration;
    public float velPower;

    //Jumping Variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    bool facingRight;
    Rigidbody2D myRB;
    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {

        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
    }

    private void Update()
    {
     if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }   
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Check if we are grounded if no we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float moveInput = Input.GetAxis("Horizontal");

        myAnim.SetFloat("speed", Mathf.Abs(moveInput));

        float targetSpeed = moveInput * moveSpeed;
        float speedDif = targetSpeed - myRB.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        myRB.AddForce(movement * Vector2.right);

        if (moveInput > 0 && !facingRight)
        {
            flip();
        }
        else if (moveInput < 0 && facingRight) {
            flip();
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
