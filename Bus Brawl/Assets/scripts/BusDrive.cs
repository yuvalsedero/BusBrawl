using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusDrive : MonoBehaviour
{
    Vector2 positionToMoveTo;
    private Rigidbody2D body;
    [SerializeField] public float speed;
    public float secToWait;
    bool Wait = false;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
         positionToMoveTo = GameObject.FindGameObjectWithTag("BusParking").transform.position; // get bus entrance position
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(BusWait());
        if (Wait)
        {
        Vector2 targetPosition = Vector2.MoveTowards(transform.position, positionToMoveTo, speed * Time.deltaTime); // enemy moving torwads bus entrance
        body.transform.position = targetPosition;
        }
 
   }
   IEnumerator BusWait()
   {
       yield return new WaitForSeconds(secToWait);
       Wait = true;
   }
}
