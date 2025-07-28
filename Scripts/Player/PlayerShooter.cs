using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager; // Referencia al WeaponManager
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private float fireRate = 0.25f;
    private float canFire = 0.0f;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    private void Update()
    {
        if (weaponManager.GetCurrentWeaponPrefab() == null) return;

        Shoot();
        MegaBomb();
        ChangeWeapon();
    }

    private void Shoot()
    {
        if (playerInputActions.Shooter.Fire.triggered && Time.time > canFire)
        {
            GameObject weaponPrefab = weaponManager.GetCurrentWeaponPrefab();

            if (weaponPrefab.name == "SingleLaser")
            {
                fireRate = 0.30f;
                Instantiate(weaponPrefab, transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
            }
            else if (weaponPrefab.name == "DoubleLaser")
            {
                fireRate = 0.12f;
                Instantiate(weaponPrefab, transform.position + new Vector3(0.7f, 0, 0), Quaternion.identity);
            }
            else if (weaponPrefab.name == "TripleLaser")
            {
                fireRate = 0.20f;
                Instantiate(weaponPrefab, transform.position + new Vector3(0.3f, -0.4f, 0), Quaternion.Euler(0, 0, 0));
                Instantiate(weaponPrefab, transform.position + new Vector3(-0.3f, -0.01f, 0), Quaternion.Euler(0, 0, 15f));
                Instantiate(weaponPrefab, transform.position + new Vector3(-0.5f, -0.7f, 0), Quaternion.Euler(0, 0, -15f));
            }
            else if (weaponPrefab.name == "OndaLaser")
            {
                fireRate = 0.15f;
                Instantiate(weaponPrefab, transform.position + new Vector3(0.7f, 0, 0), Quaternion.identity);
            }

            canFire = Time.time + fireRate;
        }
    }

    private void MegaBomb()
    {
        if (playerInputActions.Shooter.Special.triggered)
        {
            if (HasMegaBomb())
            {
                LaunchBomb();
            }
        }
    }

    private void LaunchBomb()
    {
        cameraShake.Shake(0.5f, 0.5f);
    }

    public bool HasMegaBomb()
    {
        return true;
    }

    private void ChangeWeapon()
    {
        if (playerInputActions.Shooter.WeaponPrevious.triggered)
        {
            weaponManager.PreviousWeapon();
        }
        else if (playerInputActions.Shooter.WeaponNext.triggered)
        {
            weaponManager.NextWeapon();
        }
    }
}
