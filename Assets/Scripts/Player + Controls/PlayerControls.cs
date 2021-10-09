using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private Controls _playerKbMove;

    [Header("References")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;

    [Header("Variables")] 
    [SerializeField] private float _speed = 0.5f;

    private Vector2 _moveInput = Vector2.zero;


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
        _moveInput = Vector2.ClampMagnitude(_playerKbMove.Keyboard.Move.ReadValue<Vector2>(), 1.0f);
        _rb.velocity = _moveInput * _speed;

    }

    void Update()
    {
        Animate();
    }

    void Interact()
    {
        InteractionManager.Instance.CallEvent();
    }

    void Animate()
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame || 
            Keyboard.current.wKey.wasPressedThisFrame)
        {
            _animator.SetInteger("Direction", 1);
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame ||
                 Keyboard.current.sKey.wasPressedThisFrame)
        {
            _animator.SetInteger("Direction", 0);
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame ||
                 Keyboard.current.aKey.wasPressedThisFrame)
        {
            _animator.SetInteger("Direction", 3);
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame ||
                 Keyboard.current.dKey.wasPressedThisFrame)
        {
            _animator.SetInteger("Direction", 2);
        }


        _animator.SetBool("IsMoving", _moveInput != Vector2.zero);
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
