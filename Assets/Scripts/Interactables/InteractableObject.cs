using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractableObject : Interactable
{
    public List<Dialogue> script = new List<Dialogue>();
    public List<Dialogue> script2 = new List<Dialogue>();
    public AudioClip sfx;
    public bool showScript = true;
    public bool hasOne;
    public Vector2 onePosition;
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
        Door.doorEvent += ChangeDialogue;
    }

    protected void OnDisable()
    {
        InteractionManager.interactionEvent -= Interact;
        DialogueManager.enableEvent -= Reenable;
        Door.doorEvent -= ChangeDialogue;
    }

    protected void Interact()
    {
        if (canInteract)
        {
            //Debug.Log("interacted with " + gameObject);
            //interactRange.gameObject.SetActive(false);
            if (hasOne)
            {
                DialogueManager.Instance.SetOnePosition(onePosition);
            }

            DialogueManager.Instance.DisplayText(script, sfx);
        }
    }

    protected void Reenable()
    {
        interactRange.gameObject.SetActive(!interactRange.gameObject.activeSelf);
    }


    protected void ChangeDialogue()
    {
        script = script2.Count > 0 ? script2 : script;
    }

}
