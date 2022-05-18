using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRock : MonoBehaviour
{
    [SerializeField] float shootingDistance = 7f;
    [SerializeField] float shotSpeed = 5f;
    [SerializeField] float fireRate = 2f;
    public Animator animator;
    public GameObject rock;
    GameObject target;
    bool canShoot = true;
    // public Animator anim;
    void Start()
    {
    }
    void Update ()
    {
        if (canShoot) {
            canShoot = false;
            //Coroutine for delay between shooting
            StartCoroutine("AllowToShoot");
            //array with enemies
            //you can put in start, iff all enemies are in the level at beginn (will be not spawn later)
            GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Player");
            if (allTargets != null)
            {
                target = allTargets[0];
                //look for the closest
                foreach (GameObject tmpTarget in allTargets)
                {
                    if (Vector2.Distance(transform.position, tmpTarget.transform.position) < Vector2.Distance(transform.position, target.transform.position))
                    {
                        target = tmpTarget;
                    }
                }
                // Animator targetAnimation = target.GetComponent<EnemyHealth>().animator; // BUG!! change to playerhealth!
                //shoot if the closest is in the fire range
                if (Vector2.Distance(transform.position, target.transform.position) < shootingDistance) //&& targetAnimation.GetBool("Dead") == false)
                {
                    Fire();
                }
            }
        }
    }
 
    void Fire ()
    {
        animator.SetTrigger("Attack");
        Vector2 direction = target.transform.position - transform.position;
        //link to spawned arrow, you dont need it, if the arrow has own moving script
        GameObject tmpRock = Instantiate(rock, transform.position, transform.rotation);
        tmpRock.transform.right = direction;
        tmpRock.GetComponent<Rigidbody2D>().velocity = direction.normalized * shotSpeed;
    }
   
    IEnumerator AllowToShoot ()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
