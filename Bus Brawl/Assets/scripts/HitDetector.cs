using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    [SerializeField] int Damage = 10;
    PlayerHealth playerHP;
    public bool penetration;
    bool doDmg = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == ("Player"))
        {
            playerHP = other.gameObject.GetComponent<PlayerHealth>();
            playerHP.TakeDamage(Damage);
            if (!penetration)
                Destroy(this.gameObject);
        }
    }
    //this is for the eagle in the second game yuval made (we can use it in the future)
    // void OnTriggerStay2D(Collider2D other)
    // {
        
    //     if (other.gameObject.tag == ("Player") && doDmg)
    //     {
    //         doDmg = false;
    //         //Coroutine for delay between shooting
    //         StartCoroutine("Delay");
    //         playerHP = other.gameObject.GetComponent<EnemyHealth>();
    //         playerHP.TakeDamage(Damage);
    //         if (!penetration)
    //             Destroy(this.gameObject);
    //     }
    // }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        doDmg = true;
    }
}
