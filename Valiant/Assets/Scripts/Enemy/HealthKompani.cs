using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKompani : MonoBehaviour
{
    public int maxHealth = 1; // Jumlah HP maksimum dari enemy
    private int currentHealth; // Jumlah HP saat ini dari enemy
    private Animator anim;

    void Start()
    {
        currentHealth = maxHealth; // Set jumlah HP awal enemy
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Kurangi jumlah HP enemy dengan jumlah damage yang diterima
        if (currentHealth <= 0)
        {
            Die(); // Jika jumlah HP enemy habis, panggil fungsi Die()
        }
    }

    void Die()
    {
        //anim.SetTrigger("isDead");
        Destroy(gameObject); // Hancurkan game object dari enemy
    }
}
