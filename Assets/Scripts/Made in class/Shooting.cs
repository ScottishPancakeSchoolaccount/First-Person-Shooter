

using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public Camera cam;

    private Ray ray;
    private RaycastHit hit;

    private int enemiesDestroyed = 0; // Counter for enemies destroyed

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag.Equals("NPC"))
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log("DIE DIE DIE!");

                    // Increment the counter and check for victory condition
                    enemiesDestroyed++;
                    if (enemiesDestroyed >= 20)
                    {
                        // Load the "Victory" scene
                        SceneManager.LoadScene("Victory");
                    }
                }
            }
        }
    }
}


