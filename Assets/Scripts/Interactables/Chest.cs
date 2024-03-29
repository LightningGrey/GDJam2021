using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private Animator _chestAnimator;

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
        if (canInteract && !_chestAnimator.GetBool("Open"))
        {
            _chestAnimator.SetBool("Open", true);
            interactRange.gameObject.SetActive(false);
        }
    }

}
