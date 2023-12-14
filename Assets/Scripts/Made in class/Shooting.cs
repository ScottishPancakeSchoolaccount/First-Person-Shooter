using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera cam;
    //    public GameObject bulletPrefab;
    //    public Transform gunBarrel;

    //    private Ray ray;
    //    private RaycastHit hit;

    //    // Update is called once per frame
    //    void Update()
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            // Spawn a bullet at the gun barrel position
    //            GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);

    //            // Get the Bullet script attached to the bullet GameObject
    //            Bullet bulletScript = bullet.GetComponent<Bullet>();

    //            // Check if the bullet has the Bullet script
    //            if (bulletScript != null)
    //            {
    //                // Set the direction of the bullet based on the camera's forward direction
    //                bulletScript.SetDirection(cam.transform.forward);
    //            }

    //            // Destroy the bullet after a certain time (adjust as needed)
    //            Destroy(bullet, 2f);

    //            // Perform raycast to check if it hits an enemy
    //            ray = cam.ScreenPointToRay(Input.mousePosition);
    //            if (Physics.Raycast(ray, out hit))
    //            {
    //                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

    //                if (enemyHealth != null)
    //                {
    //                    enemyHealth.TakeDamage(10); // Adjust the damage amount as needed
    //                    Debug.Log("DIE DIE DIE!");
    //                }
    //            }
    //        }
    //    }
    //}



    private Ray ray;
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(10); // Adjust the damage amount as needed
                    Debug.Log("DIE DIE DIE!");
                }
            }
        }
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Shooting : MonoBehaviour
//{

//    public Camera cam;

//    private Ray ray;
//    private RaycastHit hit;

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            ray = cam .ScreenPointToRay(Input.mousePosition);
//            if (Physics.Raycast(ray, out hit))
//            {
//                if (hit.collider.tag.Equals("NPC"))
//                {
//                    Destroy(hit.collider.gameObject);
//                    Debug.Log("DIE DIE DIE!");
//                } 

//            }
//        }
//    }
//}
