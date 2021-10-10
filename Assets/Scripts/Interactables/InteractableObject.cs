using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InteractableObject : Interactable
{
    [HideInInspector] public List<Dialogue> script = new List<Dialogue>();
    [HideInInspector] public bool showScript = true;
    [HideInInspector] public bool hasOne;
    [HideInInspector] public Vector2 onePosition;

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
