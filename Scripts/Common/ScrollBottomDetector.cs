using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBottomDetector : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Button bottomButton;

    private void Start()
    {
        // Suscribirse al evento de cambio de scroll del ScrollView
        scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
        bottomButton.interactable = false;
    }

    private void OnDestroy()
    {
        // Asegurarse de eliminar la suscripción al destruir el objeto
        scrollRect.onValueChanged.RemoveListener(OnScrollValueChanged);
    }

    private void OnScrollValueChanged(Vector2 value)
    {
        // Si el scroll está en el fondo (cerca de 1 en la posición y)
        if (value.y <= 0.02f)
        {
            bottomButton.interactable = true;
        }
        else
        {
            bottomButton.interactable = false;
        }
    }
}

