using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;
using UnityEngine.UI;
using TMPro;

public class QualityOptions : MonoBehaviour
{
    [Tooltip("Seleccionable de opciones de calidad de gráficos")][SerializeField] public TMP_Dropdown dropdownQA;
    [Tooltip("Calidad de los graficos")][SerializeField] public int quality;

    void Start()
    {
        quality = PlayerPrefs.GetInt("qualityNumber", 3);
        dropdownQA.value = quality;
        QualitySetting();
    }

    public void QualitySetting()
    {
        QualitySettings.SetQualityLevel(dropdownQA.value);
        PlayerPrefs.SetInt("qualityNumber", dropdownQA.value);
        quality = dropdownQA.value;
    }
}
