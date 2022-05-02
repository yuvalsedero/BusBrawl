using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BusCollider : MonoBehaviour
{
    bool isEnemyColliding = false;
    static float timeToDestroy = 3.0f;
    float timerCountDown = timeToDestroy;
    public static int Passengers = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (isEnemyColliding == true)
        // {
        //     timerCountDown -= Time.deltaTime;
        //     if (timerCountDown < 0)
        //     {
        //         timerCountDown = 0;
        //         var destroyEnemy = GameObject.FindWithTag("Enemy");
        //         GameObject.Destroy(destroyEnemy, 0);// bug! this destroys a random enemy not exacly the one on collider.
        //         Passengers ++;
        //         Debug.Log("enemydestroyd");
        //         timerCountDown = timeToDestroy;
        //     }

        // }
    }
    void OnTriggerEnter2D(Collider2D other) //returns true if enemy steps on bus entrance.
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy trying to go on bus");
            isEnemyColliding = true;
        }
    }
    void OnTriggerStay2D(Collider2D other) // destroying enemy if he stands there for 3 sec.
    {
        if (other.gameObject.tag == "Enemy" && isEnemyColliding == true)
        {
            timerCountDown -= Time.deltaTime;
            if (timerCountDown <= 0)
            {
                timerCountDown = 0;
                var enemeis = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemeis)
                {
                    if (other.name == enemy.name)
                    {
                        GameObject.Destroy(enemy, 0);
                        Passengers ++;
                        Debug.Log("enemydestroyd2");
                        timerCountDown = timeToDestroy;
                    }
                }

            }
        }
    }
    void OnTriggerExit2D(Collider2D other) // if enemy leaves the entrance pre time.
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Exited");
            isEnemyColliding = false;
            timerCountDown = timeToDestroy;
        }
    }

    
}