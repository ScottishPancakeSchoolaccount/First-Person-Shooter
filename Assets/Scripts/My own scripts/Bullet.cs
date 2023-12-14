using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward in its direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Set the direction of the bullet
    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }
}

