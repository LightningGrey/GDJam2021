using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRange : MonoBehaviour
{
    private Interactable _parent;

    void Awake()
    {
        _parent = gameObject.transform.parent.GetComponent<Interactable>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("entered");
            _parent.CanInteract = true;
        }

    }

    void OnTriggerExit2D()
    {
        _parent.CanInteract = false;
    }
}
