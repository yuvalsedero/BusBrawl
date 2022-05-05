using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public Animator animator;
    float health;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider2D>().enabled = true;
        health = maxHealth;
        slider.value = CalculateHealth();
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
