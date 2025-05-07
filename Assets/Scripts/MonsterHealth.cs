using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [Header("Monster Settings")]
    public int maxHealth = 3;
    private int currentHealth;

	// Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
	
	// Update is called once per frame
    void Update()
    {
		
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Optional: play death animation/effects
        Destroy(gameObject);
    }
	
}
