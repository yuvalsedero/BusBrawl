using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    float health;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt");
        // animator.SetTrigger("Hurt");
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
        Debug.Log("You Died");
        
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
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
