using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootEmUpController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 _movementInput;

    private void OnEnable()
    {
        var playerInput = GetComponent<PlayerInput>();
        playerInput.actions["Move"].performed += OnMove;
        playerInput.actions["Move"].canceled += OnMove;
        playerInput.actions["Shoot"].performed += OnShoot;
    }

    private void OnDisable()
    {
        var playerInput = GetComponent<PlayerInput>();
        playerInput.actions["Move"].performed -= OnMove;
        playerInput.actions["Move"].canceled -= OnMove;
        playerInput.actions["Shoot"].performed -= OnShoot;
    }

    private void Update()
    {
        Move();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(_movementInput.x, _movementInput.y, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
        Debug.Log($"Move Input: {_movementInput}");
        Debug.Log($"Shoot triggered");
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Shoot!");
        // Implementar lógica de disparo
    }
}

