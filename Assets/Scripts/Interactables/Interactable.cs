using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected CircleCollider2D interactRange;
    protected bool canInteract = false;

    public bool CanInteract
    {
        get => canInteract;
        set => canInteract = value;
    }
    
    void Interact() { }
    
}
