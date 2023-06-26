using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 3;
    public HealthBar healthBar;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            TakeDamage(1);
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

    }
    public void Healer(int amount)
    {
        currentHealth += amount;
        healthBar.SetHealth(currentHealth);

    } 
}
