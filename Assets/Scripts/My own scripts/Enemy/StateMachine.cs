using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState;
    //property for the patrol state.

    public void Initialise()
    {
        patrolState = new PatrolState();
        ChangeState(patrolState);   
    }
    void Start()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeState(BaseState newState)
    {
        //Check activeState != null
        if(activeState != null) 
        { 
            //run cleanup on activeState
            activeState.Exit();
        }
        //change to a new state.
        activeState = newState;

        //fail-safe null check to make sure new state wasn't null
        if(activeState != null )
        {
            //Setup new state.
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
