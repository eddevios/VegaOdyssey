using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public enum GameMode { Shooter, Runner }
    public GameMode currentMode = GameMode.Shooter;

    [Header("PROPIEDADES DEL PLAYER")]
    [Tooltip("Velocidad de movimiento del player")]
    [SerializeField] public float speedMovement = 2f;
    [Tooltip("Si tiene Boost de Velocidad el player")]
    [SerializeField] public bool isSpeedBoostActive;
    [Tooltip("Velocidad de Boost")]
    [SerializeField] public float boostSpeed = 1.5f;
    [Tooltip("Si tiene Escudo el player")]
    [SerializeField] public bool isShieldActive;
    [Tooltip("Referencia al Player Manager")]
    [SerializeField] private PlayerManager _player;
    [Tooltip("Límites de pantalla")]
    [SerializeField] private float _minX, _maxX, _minY, _maxY;

    private Vector2 movementInput;
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        // Buscar el PlayerManager en la escena
        _player = FindObjectOfType<PlayerManager>();
        if (_player == null)
        {
            Debug.LogError("PlayerManager no encontrado. Asegúrate de que está asignado.");
        }

        // Calcular los límites de la pantalla
        CalculateScreenLimits();

        // Inicializar las acciones del sistema de entrada
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
    }

    private void OnEnable()
    {
        _playerInputActions.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Disable();
    }

    private void Start()
    {
        transform.position = Vector3.zero;
    }

    private void Update()
    {
        if (!_player.IsDead)
        {
            PlayerInputMovement();
            ClampPosition();
        }
        else
        {
            isSpeedBoostActive = false;
            isShieldActive = false;
        }
    }

    #region Player Input
    private void PlayerInputMovement()
    {
        Vector2 inputVector;

        if (currentMode == GameMode.Shooter)
        {
            inputVector = _playerInputActions.Shooter.Move.ReadValue<Vector2>();
        }
        else if (currentMode == GameMode.Runner)
        {
            inputVector = _playerInputActions.Runner.Move.ReadValue<Vector2>();
        }
        else
        {
            inputVector = Vector2.zero;
        }

        float horizontalInput = -inputVector.y;
        float verticalInput = inputVector.x;

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized * speedMovement * Time.deltaTime;

        if (isSpeedBoostActive)
        {
            movement *= boostSpeed;
        }

        transform.Translate(movement);
    }
    #endregion

    #region Límites de pantalla
    private void CalculateScreenLimits()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            float screenRatio = (float)Screen.width / (float)Screen.height;
            float cameraSize = mainCamera.orthographicSize;

            _minX = -cameraSize * screenRatio + cameraSize / 10;
            _maxX = cameraSize * screenRatio - cameraSize / 10;
            _minY = -cameraSize + cameraSize * 0.1f;
            _maxY = cameraSize - cameraSize * 0.18f; // 8% menos para el HUD.
        }
        else
        {
            Debug.LogError("Cámara principal no encontrada.");
        }
    }
    #endregion

    #region Límites de Player
    private void ClampPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, _minX, _maxX);
        float clampedY = Mathf.Clamp(transform.position.y, _minY, _maxY);

        transform.position = new Vector3(clampedX, clampedY, 0);
    }
    #endregion
}