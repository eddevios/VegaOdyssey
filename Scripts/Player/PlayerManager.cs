using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private string _currentMode;

    public bool IsDead { get; private set; }

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        if (_playerInput == null)
        {
            Debug.LogError("PlayerInput no encontrado.");
        }
        else
        {
            SwitchToShootEmUpMode(); // Inicia en modo shoot 'em up.
            IsDead = false; // El jugador inicia vivo.
        }
    }

    public void SwitchToShootEmUpMode()
    {
        _currentMode = "Shooter";
        _playerInput.SwitchCurrentActionMap(_currentMode);
        EnableController<ShootEmUpController>();
        DisableController<RunAndGunController>();
    }

    public void SwitchToRunAndGunMode()
    {
        _currentMode = "Runner";
        _playerInput.SwitchCurrentActionMap(_currentMode);
        EnableController<RunAndGunController>();
        DisableController<ShootEmUpController>();
    }

    private void EnableController<T>() where T : MonoBehaviour
    {
        var controller = GetComponent<T>();
        if (controller != null) controller.enabled = true;
    }

    private void DisableController<T>() where T : MonoBehaviour
    {
        var controller = GetComponent<T>();
        if (controller != null) controller.enabled = false;
    }

    // Método público para marcar al jugador como muerto.
    public void SetDead()
    {
        IsDead = true;
        Debug.Log("El jugador ha sido marcado como muerto.");
    }

}