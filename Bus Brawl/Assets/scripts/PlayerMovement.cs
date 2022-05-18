using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator animator;
    [SerializeField] public float runSpeed = 20.0f;

    private Vector2 moveInput;
    private float activeRunSpeed;
    private float dashSpeed = 10f;
    public float dashLength = .25f;
    public float dashCooldown = 1f;
    private float dashCounter = 0f;
    private float dashCoolCounter;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        activeRunSpeed = runSpeed;
    }

    void Update() // get input of movement
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        

        animator.SetFloat("Speed", Mathf.Abs(moveInput.x)); //set animation of walking

        if (Input.GetKeyDown("space"))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0) // Dash
            {
                animator.SetTrigger("Dash");
                activeRunSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeRunSpeed = runSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate() // set body movement to run speed and the directions from update
    {
        body.velocity = moveInput * activeRunSpeed;
        if (body.velocity.x > 0)
        {
            transform.localScale = new Vector2(0.75f, 0.75f);
        }
            else if (body.velocity.x < 0)
            {
                transform.localScale = new Vector2(-0.75f, 0.75f);
            }
        
    }
}