using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private Controls _playerKbMove;

    [Header("References")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] public GameObject _interactText;

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
        if (_moveInput.x > 0)
        {
            _animator.SetInteger("Direction", 2);
        }
        else if (_moveInput.x < 0)
        {
            _animator.SetInteger("Direction", 3);
        }

        if (_moveInput.y > 0)
        {
            _animator.SetInteger("Direction", 1);
        }
        else if (_moveInput.y < 0)
        {
            _animator.SetInteger("Direction", 0);
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
