using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //Variables
    public NavMeshAgent badGuy;
    public float squareOfMovement = 20f;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;
    private float xPosition;
    private float yPosition;
    private float zPosition;
    public float closeEnough = 2f;

    // Start is called before the first frame update
    void Start()
    {
        xMin = -squareOfMovement;
        xMax = squareOfMovement;
        zMin = -squareOfMovement;
        zMax = squareOfMovement;

        NewLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosition, yPosition, zPosition)) <= closeEnough)
        {
            NewLocation();
        } 
    }

    //Containers
    public void NewLocation()
    {
        yPosition = transform.position.y;
        xPosition = Random.Range(xMin, xMax);
        zPosition = Random.Range(zMin, zMax);

        badGuy.SetDestination(new Vector3(xPosition, yPosition, zPosition));
    }
}
