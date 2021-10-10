using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Interactable : MonoBehaviour
{
    public Collider2D interactRange;
    protected bool canInteract = false;

    public bool CanInteract
    {
        get => canInteract;
        set => canInteract = value;
    }
    
    void Interact() { }
    
}
