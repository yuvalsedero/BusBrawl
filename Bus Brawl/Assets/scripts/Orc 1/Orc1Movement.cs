using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc1Movement : MonoBehaviour

{
    public float thrust;
    public float knockBackTime;

    public Animator animator;
    private Rigidbody2D body;
    Vector2 positionToMoveTo;
    Vector2 enemyFirstSteps;
    Vector2 targetPosition;
    public float speed;
    private void Awake()
    {
        GetComponent<Collider2D>().enabled = true;
        body = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyFirstSteps = GameObject.FindGameObjectWithTag("EnemySpawnWalk").transform.position; // get position of map before going to the bus position
        positionToMoveTo = GameObject.FindGameObjectWithTag("Bus").transform.position; // get bus entrance position  
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPosition = Vector2.MoveTowards(transform.position, enemyFirstSteps, speed * Time.deltaTime); // enemy moving torwads map entrance

        if (body.transform.position == targetPosition.position)
            {
            Vector2 targetPosition = Vector2.MoveTowards(transform.position, positionToMoveTo, speed * Time.deltaTime); // enemy moving torwads bus entrance
            body.transform.position = targetPosition;
            }
        
        animator.SetFloat("Speed", speed);
        if (animator.GetBool("IsDead"))
        {
            this.enabled = false;
        }
    }
    public void knockback()
    {
        Rigidbody2D orc = GetComponent<Rigidbody2D>();
        if(orc != null)
        {
            Vector2 difference = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
            difference = difference.normalized * (thrust * -1);
            orc.AddForce(difference, ForceMode2D.Impulse);

            StartCoroutine(knockCo(orc));
        }
        IEnumerator knockCo(Rigidbody2D orc)
        {
            if(orc != null)
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


