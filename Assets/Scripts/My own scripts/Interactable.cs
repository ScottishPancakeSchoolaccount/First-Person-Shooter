using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Add or remove an InteractionEvent component to this gameObject.
    public bool useEvents;
    [SerializeField]    
    public string promptMessage;

    public virtual string OnLook()
    {
        return promptMessage;
    }

    public void BaseInteract()
    {
        if(useEvents)
           GetComponent<InteractionEvent>().OnInteract.Invoke();
        
        Interact();
    }
    protected virtual void Interact()
    {
        //We wont have any code called from the base Interactable script.
        //Any custom code will go inside of this method on our inherited scripts.
    }
}
