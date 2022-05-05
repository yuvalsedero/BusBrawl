using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc1Movement : MonoBehaviour

{
    public Animator animator;
    float knockBackTimer = 3.0f;
    private Rigidbody2D body;
    Vector2 positionToMoveTo;
    public Vector2 targetPosition;
    [SerializeField] public float speed;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
         positionToMoveTo = GameObject.FindGameObjectWithTag("Bus").transform.position; // get bus entrance position
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPosition = Vector2.MoveTowards(transform.position, positionToMoveTo, speed * Time.deltaTime); // enemy moving torwads bus entrance
        body.transform.position = targetPosition;
        animator.SetFloat("Speed", speed);
        if(animator.GetBool("IsDead"))
        {
            this.enabled = false;
        }
    }
    public void knockBack()
    {
        
        // speed = speed *-1;
        Debug.Log("knockback");
        // knockBackTimer -= Time.deltaTime;
        // if (knockBackTimer <= 0)
        // {
        //     speed = speed *-1;

        // }
        // Debug.Log("after");
        // while (knockBackTimer > 0)
        // {
        //     Debug.Log("hello");
       
        // }
            
        
    }
}
