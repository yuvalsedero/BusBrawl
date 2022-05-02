using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    [SerializeField] public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

    void Update() // get input of movement
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() // set body movement to run speed and the directions from update
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
    void OnCollisionEnter2D(Collision2D collision) // killing enemy on contact
    {
        if(collision.gameObject.tag == "Enemy"){
            Destroy(collision.gameObject);
        }
    }
}
