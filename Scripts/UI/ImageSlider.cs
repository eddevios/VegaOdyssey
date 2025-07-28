using UnityEngine;
using UnityEngine.UI;

public class ImageSlider : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private RectTransform[] images; // Las im�genes de las armas en el UI
    private int currentIndex = 0; // �ndice de las im�genes en el slider
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
        // Usamos las acciones del sistema de entrada para cambiar de arma
        if (playerInputActions.Shooter.WeaponNext.triggered)
        {
            currentIndex = (currentIndex + 1) % images.Length;
            weaponManager.SetWeapon(currentIndex);  // Actualizamos la selecci�n de arma
            UpdateImageSelection();  // Actualizamos la imagen en el slider
        }

        if (playerInputActions.Shooter.WeaponPrevious.triggered)
        {
            currentIndex = (currentIndex - 1 + images.Length) % images.Length;
            weaponManager.SetWeapon(currentIndex);  // Actualizamos la selecci�n de arma
            UpdateImageSelection();  // Actualizamos la imagen en el slider
        }
    }

    private void UpdateImageSelection()
    {
        // Actualizamos el color de las im�genes seg�n el �ndice actual
        for (int i = 0; i < images.Length; i++)
        {
            Color color = i == currentIndex ? Color.white : new Color(0.3686f, 0.3686f, 0.3686f);
            images[i].GetComponent<Image>().color = color;
        }
    }
}
