using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //Variables
    private EnemyMovement enemyMovement;
    private Transform player;
    public float attackRange = 10f;

    //Variables calling to texture of enemy
    public Material defaultMaterial;
    public Material attackMaterial;
    private Renderer rend;

    private bool foundPlayer; 

    private void Awake()
    { //from the enemy movement script, it calls the other script
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<EnemyMovement>(); 
        rend = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            rend.sharedMaterial = attackMaterial;
            enemyMovement.badGuy.SetDestination(player.position);
            foundPlayer = true;
            Debug.Log("YOU DIED!");
        }
        else if (foundPlayer)
        {
            rend.sharedMaterial = defaultMaterial;
            enemyMovement.NewLocation();
            foundPlayer = false;
        }
    }
}
