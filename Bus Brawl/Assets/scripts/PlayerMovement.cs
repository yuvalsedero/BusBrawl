using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    // bool Fire1;
    [SerializeField] public float runSpeed = 20.0f;
    public Animator animator;
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

    void Update() // get input of movement
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(horizontal)); //set animation of walking
        if(Input.GetButtonDown("Fire1")) // make the attack animation
        {
            // Fire1 = true;
            animator.SetBool("isFire1", true);
        }
        if(Input.GetButtonUp("Fire1"))  // make the animation stop when it is down (bool sets to false again)
            {
                animator.SetBool("isFire1", false);
            }
    }

    private void FixedUpdate() // set body movement to run speed and the directions from update
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
         if (body.velocity.x > 0)
         {
             transform.localScale = new Vector2(0.75f, 0.75f);
         }
         else if (body.velocity.x < 0)
         {
             transform.localScale = new Vector2(-0.75f, 0.75f);
         }
 }
    
    void OnCollisionEnter2D(Collision2D collision) // killing enemy on contact
    {
        if(collision.gameObject.tag == "Enemy"){
            Destroy(collision.gameObject);
        }
    }
}
