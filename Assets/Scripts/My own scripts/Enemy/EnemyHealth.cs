using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20;
    private int currentHealth;
    public Material lowHealthMaterial;
    Renderer rend;

    void Start()
    {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
    
    }


    public void TakeDamage(int damageAmount)
    {
        // Reduce health
        currentHealth -= damageAmount;

        // Clamp the health to be within the range [0, maxHealth]
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update material based on health
        UpdateMaterial();

        // Check if the enemy is defeated

            Die();
        
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    void UpdateMaterial()
    {
        // Update material based on health
        if (rend != null && lowHealthMaterial != null)
        {
            float healthPercentage = (float)currentHealth / maxHealth;

            // Check if health is above a certain threshold
            if (healthPercentage > 0f)
            {
                rend.material = lowHealthMaterial;
            }
            // You can add an else condition here if you want to handle different cases
        }
    }
    void Die()
    {
        // Add any death effects or logic here

        // For example, you can destroy the enemy GameObject
        Destroy(gameObject);
    }
 }
  
    





