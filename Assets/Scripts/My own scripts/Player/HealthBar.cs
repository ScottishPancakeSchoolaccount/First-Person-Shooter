using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    [Header("Health Bar")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;

    [Header("Damage Overlay")]
    public Image overlay; //out DamageOverlay GameObject
    public float duration; //how long the image stays fully opqaque
    public float fadeSpeed; //how quickly the image will fade

    private float durationTimer; //timer to check against the duration
    void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);

    }

    // Update is called once per frame
    void Update()
    {
       
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if(overlay.color.a > 0)
        {
            if (health < 30)
                return;
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                //fade the image
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r,overlay.color.g,overlay.color.b, tempAlpha);
            }
        }

        //This is meant to check if the chip speed worked <3
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    TakeDamage(Random.Range(5, 10));
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    RestoreHealth(Random.Range(5, 10));
        //}
    }
    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if(fillB > hFraction) 
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer/ chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF,backHealthBar.fillAmount,percentComplete); 
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);

    }
    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }
}
