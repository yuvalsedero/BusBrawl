using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    float horizontal;
    float vertical;
    // bool Fire1;
    [SerializeField] public float runSpeed = 20.0f;
    public Animator animator;
    void Start()
    {
        GetComponent<Collider2D>().enabled = true;
        body = GetComponent<Rigidbody2D>(); 
        
    }

    void Update() // get input of movement
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(horizontal)); //set animation of walking
        var pos = Mathf.Round(transform.position.y);
        
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

}
