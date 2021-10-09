using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveInput = _playerKbMove.Movement.Move.ReadValue<Vector2>();
        _rb.velocity = moveInput * _speed;

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
