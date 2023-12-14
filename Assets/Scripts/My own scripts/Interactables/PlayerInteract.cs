using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);

        // Create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);

                if (inputManager.onFoot.Interact.triggered)
                {
                    // Check if the interactable is an enemy
                    if (interactable is EnemyInteractable)
                    {
                        // Damage the enemy
                        DamageEnemy((EnemyInteractable)interactable);
                    }
                    else
                    {
                        // Handle other interactables
                        interactable.BaseInteract();
                    }
                }
            }
        }
    }

    void DamageEnemy(EnemyInteractable enemyInteractable)
    {
        // You can adjust the damage amount as needed
        int damageAmount = 10;

        // Deal damage to the enemy
        enemyInteractable.TakeDamage(damageAmount);

        // Check if the enemy is defeated
        if (enemyInteractable.IsDead())
        {
            // Handle enemy death (e.g., play death animation, remove from the scene, etc.)
            Destroy(enemyInteractable.gameObject);
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerInteract : MonoBehaviour
//{
//    private Camera cam;
//    [SerializeField]
//    private float distance = 3f;
//    [SerializeField]
//    private LayerMask mask;
//    private PlayerUI playerUI;
//    private InputManager inputManager;
//    // Start is called before the first frame update
//    void Start()
//    {
//        cam = GetComponent<PlayerLook>().cam;
//        playerUI = GetComponent<PlayerUI>();
//        inputManager = GetComponent<InputManager>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        playerUI.UpdateText(string.Empty);
//        //Create a ray at the center of the camera, shooting outwards.
//       Ray ray = new Ray(cam.transform.position, cam.transform.forward);
//        Debug.DrawRay(ray.origin, ray.direction * distance);
//        RaycastHit hitInfo;
//      if  (Physics.Raycast(ray, out hitInfo, distance, mask))
//        {
//            if(hitInfo.collider.GetComponent<Interactable>() != null) 
//            {
//                Interactable interactactable = hitInfo.collider.GetComponent<Interactable>();
//                playerUI.UpdateText(interactactable.promptMessage);
//                if (inputManager.onFoot.Interact.triggered)
//                {
//                    interactactable.BaseInteract();
//                }
//            }
//        }
//    }
//}
