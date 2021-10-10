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
    public GameObject triggeredObject;

    public bool getHasOne()
    {
        return hasOne;
    }

    public Vector2 getOnePosition()
    {
        return onePosition;
    }

    private void Update()
    {
        if (triggeredObject != null && OneManager.Instance.one.activeSelf)
        {
            triggeredObject.SetActive(false);
        }
        else if (triggeredObject!= null && !OneManager.Instance.one.activeSelf)
        {
            triggeredObject.SetActive(true);
        }
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
