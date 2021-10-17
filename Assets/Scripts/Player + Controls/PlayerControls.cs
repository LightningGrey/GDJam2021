using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private Controls _playerKbMove;

    [Header("References")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;

    [Header("Variables")] 
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private int _drunkMode = 1;
    private float drunkTimer = 20.0f;
    

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
        _rb.velocity = _moveInput * _speed * _drunkMode;

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
        if (_moveInput.x * _drunkMode > 0)
        {
            _animator.SetInteger("Direction", 2);
        }
        else if (_moveInput.x * _drunkMode < 0)
        {
            _animator.SetInteger("Direction", 3);
        }

        if (_moveInput.y * _drunkMode > 0)
        {
            _animator.SetInteger("Direction", 1);
        }
        else if (_moveInput.y * _drunkMode < 0)
        {
            _animator.SetInteger("Direction", 0);
        }


        _animator.SetBool("IsMoving", _moveInput != Vector2.zero);
    }

    void ControlEnable()
    {
        if (_playerKbMove.Keyboard.enabled)
        {
            _playerKbMove.Keyboard.Disable();
        }
        else
        {
            _playerKbMove.Keyboard.Enable();
        }
    }


    void SetDrunk()
    {
        _drunkMode = -1;
        StartCoroutine(DrunkMode());
    }

    IEnumerator DrunkMode()
    {
        for (float f = 0.0f; f < 1.0f; f += Time.deltaTime)
        {
            Debug.Log(f);
            yield return new WaitForSeconds(.04f);
        }

        _drunkMode = 1;
        StopCoroutine(DrunkMode());
    }


    void OnEnable()
    {
        _playerKbMove.Keyboard.Enable();
        DialogueManager.enableEvent += ControlEnable;
        OutlineChest.chestEvent += SetDrunk;
    }

    void OnDisable()
    {
        _playerKbMove.Keyboard.Disable();
        DialogueManager.enableEvent -= ControlEnable;
        OutlineChest.chestEvent -= SetDrunk;
    }

}
