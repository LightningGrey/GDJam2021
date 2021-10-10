using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance { get; private set; }

    public static event Action interactionEvent;
    [SerializeField] private GameObject _interactText;


    void OnEnable()
    {
        InteractRange.interactionText += InteractText;
    }

    void OnDisable()
    {
        InteractRange.interactionText -= InteractText;
    }


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void CallEvent()
    {
        interactionEvent?.Invoke();
    }

    void InteractText()
    {
        _interactText.SetActive(!_interactText.activeSelf);
    }


}
