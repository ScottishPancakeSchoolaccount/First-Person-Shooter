using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAttack : MonoBehaviour
{
    // Variables
    public Material lowHealthMaterial;
    private EnemyHealth enemyHealth;

    private EnemyMovement enemyMovement;
    private Transform player;
    public float spotRange = 15f;
    public float attackRange = 1f;
    public int damageAmount = 1; // Adjust the damage amount as needed
    public float attackDelay = 2f; // Adjust the delay between attacks

    // Variables calling to texture of enemy
    public Material defaultMaterial;
    public Material attackMaterial;
    private Renderer rend;

    private bool foundPlayer;
    private float timeSinceLastAttack;

    private void Awake()
    {
        // from the enemy movement script, it calls the other script
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<EnemyMovement>();
        rend = GetComponent<Renderer>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastAttack = attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= spotRange)
        {
            int currentHealth = enemyHealth.GetHealth();

            if (currentHealth <=10) // Assuming 30% is the threshold for low health
            {
                rend.material.color = Color.red;  // Change color to red when health is lower than 10
            }
            else
            {
                rend.material.color = defaultMaterial.color;  // Reset to default color
            }
            // Check if you want to deal damage to the player
            if (distanceToPlayer <= attackRange && timeSinceLastAttack >= attackDelay)
            {
                // Deal damage to the player
                DealDamageToPlayer();

                timeSinceLastAttack = 0f;
            }
            else if (foundPlayer)
            {
                rend.sharedMaterial = defaultMaterial;
                enemyMovement.NewLocation();
                foundPlayer = false;
            }
            // Player is within attack range
            rend.material.color = defaultMaterial.color;  // Reset to default color
            enemyMovement.badGuy.SetDestination(player.position);
            foundPlayer = true;

            timeSinceLastAttack += Time.deltaTime;
        }

        void DealDamageToPlayer()
        {
            // Add your code to deal damage to the player here
            player.GetComponent<HealthBar>().TakeDamage(damageAmount);
            // Make sure you have a PlayerHealth script on your player object with a TakeDamage method.
        }
    }
}

//{
//    //Variables
//    private EnemyMovement enemyMovement;
//    private Transform player;
//    public float attackRange = 10f;


//    //Variables calling to texture of enemy
//    public Material defaultMaterial;
//    public Material attackMaterial;
//    private Renderer rend;

//    private bool foundPlayer; 

//    private void Awake()
//    { //from the enemy movement script, it calls the other script
//        player = GameObject.FindGameObjectWithTag("Player").transform;
//        enemyMovement = GetComponent<EnemyMovement>(); 
//        rend = GetComponent<Renderer>();
//    }
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(Vector3.Distance(transform.position, player.position) <= attackRange)
//        {
//            rend.sharedMaterial = attackMaterial;
//            enemyMovement.badGuy.SetDestination(player.position);
//            foundPlayer = true;
//        }
//        else if (foundPlayer)
//        {
//            rend.sharedMaterial = defaultMaterial;
//            enemyMovement.NewLocation();
//            foundPlayer = false;
//        }
//    }

