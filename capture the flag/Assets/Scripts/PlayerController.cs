using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private float speed;
    private Rigidbody rb;
    private InputActionMap gameActionMap;
    private InputAction moveAction;

    private Vector2 move;

    public static PlayerController Instance { get; set; }
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        
        gameActionMap = inputActionAsset.FindActionMap("game");
        gameActionMap.Enable();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        moveAction = gameActionMap.FindAction("move");
        moveAction.performed += OnMove;
        moveAction.canceled += OnMoveCanceled;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        move = moveAction.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        move = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y) * speed;

        rb.velocity = targetVelocity;
    }

}
