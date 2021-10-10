using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interactable
{
    public List<Dialogue> script = new List<Dialogue>();
    public bool showScript = true;
    public bool hasOne = false;
    public Vector2 onePosition;

    public bool getHasOne()
    {
        return hasOne;
    }

    public Vector2 getOnePosition()
    {
        return onePosition;
    }

    void OnEnable()
    {
        InteractionManager.interactionEvent += Interact;
        DialogueManager.enableEvent += Reenable;
    }

    void OnDisable()
    {
        InteractionManager.interactionEvent -= Interact;
        DialogueManager.enableEvent -= Reenable;
    }

    void Interact()
    {
        if (canInteract)
        {
            //Debug.Log("interacted with " + gameObject);
            //interactRange.gameObject.SetActive(false);
            if (hasOne)
            {
                DialogueManager.Instance.SetOnePosition(onePosition);
            }

            DialogueManager.Instance.DisplayText(script);
        }
    }

    void Reenable()
    {
        interactRange.gameObject.SetActive(!interactRange.gameObject.activeSelf);
    }

}
