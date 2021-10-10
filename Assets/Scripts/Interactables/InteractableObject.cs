using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interactable
{

    void OnEnable()
    {
        InteractionManager.interactionEvent += Interact;
    }

    void OnDisable()
    {
        InteractionManager.interactionEvent -= Interact;
    }

    void Interact()
    {
        if (canInteract)
        {
            Debug.Log("interacted with " + gameObject);
        }
    }
}
