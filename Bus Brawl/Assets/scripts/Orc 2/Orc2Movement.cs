using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc2Movement : MonoBehaviour

{
    public Animator animator;
    private Rigidbody2D _rigidbody;
    Vector2 positionToMoveTo;
    [SerializeField] float speed;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
        _rigidbody.MovePosition(targetPosition);
        animator.SetFloat("Speed", speed);
        if(animator.GetBool("IsDead"))
        {
            this.enabled = false;
        }
    }
}
