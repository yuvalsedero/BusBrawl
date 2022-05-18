using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour

{
    public float thrust;
    public float knockBackTime;

    public Animator animator;
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
    }

    // Update is called once per frame
    void Update()
    {
        positionToMoveTo = GameObject.FindGameObjectWithTag("Player").transform.position; // get bus entrance position
        Vector2 targetPosition = Vector2.MoveTowards(transform.position, positionToMoveTo, speed * Time.deltaTime); // enemy moving torwads Player
        if (Vector2.Distance(positionToMoveTo, transform.position) > 5)
        {
            animator.SetFloat("Speed", speed);
            body.transform.position = targetPosition;
        }
        else{
            animator.SetFloat("Speed", 0);
            }
        if (animator.GetBool("IsDead"))
        {
            this.enabled = false;
        }
    }
    public void knockback()
    {
        Rigidbody2D orc = GetComponent<Rigidbody2D>();
        if (orc != null)
        {

            Vector2 difference = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
            difference = difference.normalized * (thrust * -1);
            orc.AddForce(difference, ForceMode2D.Impulse);

            StartCoroutine(knockCo(orc));
        }
        IEnumerator knockCo(Rigidbody2D orc)
        {
            if (orc != null)
            {
                yield return new WaitForSeconds(knockBackTime);
                orc.velocity = Vector2.zero;
                positionToMoveTo = GameObject.FindGameObjectWithTag("Bus").transform.position;
                Vector2 targetPosition = Vector2.MoveTowards(transform.position, positionToMoveTo, speed * Time.deltaTime);
                body.transform.position = targetPosition;

            }

        }
    }
}


