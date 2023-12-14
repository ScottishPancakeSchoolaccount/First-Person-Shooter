using UnityEngine;

public class EnemyInteractable : Interactable
{
    public int maxHealth = 100;
    private int currentHealth;

    // You can use Unity's built-in UI system for the health bar
    // or use a custom UI solution as needed.
    public UnityEngine.UI.Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;

        // Initialize the health bar if it is assigned
        if (healthBar != null)
        {
            healthBar.fillAmount = 1f;
        }
    }

    //public void BaseInteract()
    //{
    //    // Implement enemy-specific interaction logic if needed
    //    // This could include things like attacking the player or other behaviors
    //    base.BaseInteract();
    //}

    public void TakeDamage(int damageAmount)
    {
        // Reduce health
        currentHealth -= damageAmount;

        // Clamp the health to be within the range [0, maxHealth]
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update the health bar if it is assigned
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }

        // Check if the enemy is defeated
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    void Die()
    {
        // Add any death effects or logic here

        // For example, you can destroy the enemy GameObject
        Destroy(gameObject);
    }
}

