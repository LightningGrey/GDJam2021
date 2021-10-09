using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected CircleCollider2D interactRange;
    
    void Interact() { }
    
}
