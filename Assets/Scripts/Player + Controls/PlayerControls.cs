using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Controls _playerKbMove;

    [Header("References")]
    [SerializeField] private Rigidbody2D _rb;

    [Header("Variables")] 
    [SerializeField] private float _speed = 4.0f;


    // Start is called before the first frame update
    void Awake()
    {
        _playerKbMove = new Controls();
    }

    void Start()
    {
        _playerKbMove.Keyboard.Interact.performed += ctx => Interact();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveInput = _playerKbMove.Keyboard.Move.ReadValue<Vector2>();
        _rb.velocity = moveInput * _speed;

    }

    void Interact()
    {
        InteractionManager.Instance.CallEvent();
    }

    void OnEnable()
    {
        _playerKbMove.Enable();
    }

    void OnDisable()
    {
        _playerKbMove.Disable();
    }
}
