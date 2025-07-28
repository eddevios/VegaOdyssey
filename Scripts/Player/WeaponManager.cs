using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Armas")]
    [SerializeField] private GameObject[] weaponPrefabs; // Array para las armas (SingleLaser, DoubleLaser, TripleLaser, OndaLaser)
    [SerializeField] private int currentWeaponIndex = 0; // �ndice actual del arma
    [SerializeField] private GameObject currentWeaponPrefab; // Arma seleccionada

    private void Start()
    {
        // Establecer el prefab inicial
        SetWeapon(currentWeaponIndex);
    }

    public void SetWeapon(int index)
    {
        // Aseg�rate de que el �ndice est� dentro del rango de las armas disponibles
        if (index >= 0 && index < weaponPrefabs.Length)
        {
            currentWeaponIndex = index;
            currentWeaponPrefab = weaponPrefabs[currentWeaponIndex];
            Debug.Log("Arma seleccionada: " + weaponPrefabs[currentWeaponIndex].name);
        }
        else
        {
            Debug.LogError("�ndice de arma fuera de rango.");
        }
    }

    public void NextWeapon()
    {
        // Soluci�n: asegurarse de que el �ndice avance correctamente
        currentWeaponIndex = (currentWeaponIndex + 1) % weaponPrefabs.Length;
        SetWeapon(currentWeaponIndex);
    }

    public void PreviousWeapon()
    {
        // Soluci�n: asegurarse de que el �ndice retroceda correctamente
        currentWeaponIndex = (currentWeaponIndex - 1 + weaponPrefabs.Length) % weaponPrefabs.Length;
        SetWeapon(currentWeaponIndex);
    }

    public GameObject GetCurrentWeaponPrefab()
    {
        return currentWeaponPrefab;
    }
}
