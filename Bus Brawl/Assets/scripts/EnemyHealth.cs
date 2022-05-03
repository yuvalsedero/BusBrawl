using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D _rigidbody;

    Vector2 positionToMoveTo;
    public Animator animator;
    float health;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        positionToMoveTo = GameObject.FindGameObjectWithTag("Bus").transform.position; // get bus entrance position
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt");
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("IsDead", true);
        health = 0;
        slider.value = CalculateHealth();
        GetComponent<Collider2D>().enabled = false;
        healthBarUI.SetActive(false);
        this.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPosition = Vector2.MoveTowards(transform.position, positionToMoveTo, speed * Time.deltaTime); // enemy moving torwads bus entrance
        _rigidbody.MovePosition(targetPosition);
        slider.value = CalculateHealth();
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health < 0)
        {
            health = 0;
        }
    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
