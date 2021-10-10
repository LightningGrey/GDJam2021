using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractRange : MonoBehaviour
{
    private Interactable _parent;
    public static event Action interactionText;

    void Awake()
    {
        _parent = gameObject.transform.parent.GetComponent<Interactable>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _parent.CanInteract = true;
            interactionText?.Invoke();
        }

    }

    void OnTriggerExit2D()
    {
        _parent.CanInteract = false;
        interactionText?.Invoke();
    }
}
