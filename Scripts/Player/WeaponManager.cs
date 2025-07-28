using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Armas")]
    [SerializeField] private GameObject[] weaponPrefabs; // Array para las armas (SingleLaser, DoubleLaser, TripleLaser, OndaLaser)
    [SerializeField] private int currentWeaponIndex = 0; // Índice actual del arma
    [SerializeField] private GameObject currentWeaponPrefab; // Arma seleccionada

    private void Start()
    {
        // Establecer el prefab inicial
        SetWeapon(currentWeaponIndex);
    }

    public void SetWeapon(int index)
    {
        // Asegúrate de que el índice esté dentro del rango de las armas disponibles
        if (index >= 0 && index < weaponPrefabs.Length)
        {
            currentWeaponIndex = index;
            currentWeaponPrefab = weaponPrefabs[currentWeaponIndex];
            Debug.Log("Arma seleccionada: " + weaponPrefabs[currentWeaponIndex].name);
        }
        else
        {
            Debug.LogError("Índice de arma fuera de rango.");
        }
    }

    public void NextWeapon()
    {
        // Solución: asegurarse de que el índice avance correctamente
        currentWeaponIndex = (currentWeaponIndex + 1) % weaponPrefabs.Length;
        SetWeapon(currentWeaponIndex);
    }

    public void PreviousWeapon()
    {
        // Solución: asegurarse de que el índice retroceda correctamente
        currentWeaponIndex = (currentWeaponIndex - 1 + weaponPrefabs.Length) % weaponPrefabs.Length;
        SetWeapon(currentWeaponIndex);
    }

    public GameObject GetCurrentWeaponPrefab()
    {
        return currentWeaponPrefab;
    }
}
