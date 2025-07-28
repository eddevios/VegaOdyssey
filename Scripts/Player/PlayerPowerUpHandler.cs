using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpHandler : MonoBehaviour
{
    [Header("PROPIEDADES DEL PLAYER")]
    [Tooltip("Referencia la movimiento del player")][SerializeField] public PlayerMovement player;

    private void Update()
    {
        // Puedes hacer lo mismo para los otros power-ups (bombas, escudos, etc.)
    }

    public void ApplyPowerUp(PowerUp.PowerUpType powerUpType)
    {
        print(powerUpType.ToString());
        switch (powerUpType)
        {
            case PowerUp.PowerUpType.Speed:
                ApplySpeedPowerUp();
                break;
            case PowerUp.PowerUpType.Bomb:
                ApplyBombPowerUp();
                break;
            case PowerUp.PowerUpType.Shield:
                ApplyShieldPowerUp();
                break;
            default:
                Debug.LogError("Tipo de power-up no reconocido");
                break;
        }
    }

    private void ApplySpeedPowerUp()
    {
        print("SPEED");
        player.isSpeedBoostActive = true;
    }

    private void ApplyBombPowerUp()
    {
        print("BOOOM");
    }

    private void ApplyShieldPowerUp()
    {
        print("SHIELD");
        player.isShieldActive = true;
    }
}