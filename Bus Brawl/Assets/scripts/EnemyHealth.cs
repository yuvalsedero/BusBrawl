using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    float health;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("enemydied");
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
        if(health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
