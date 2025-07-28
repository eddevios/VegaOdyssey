using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResolutionOptions : MonoBehaviour
{
    //FULL SCREEN
    [Tooltip("Casilla para activar/desactivar pantalla completa")][SerializeField] public Toggle toggle;
    [Tooltip("Desplegable con resoluciones")][SerializeField] public TMP_Dropdown resolutionDropdown;
    [Tooltip("Array de resoluciones del dispositivo")][SerializeField] Resolution[] resolutions;

    private void Start()
    {
        //FULL SCREEN
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
        CheckResolutions();
    }

    //FULL SCREEN
    public void ActiveFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    //RESOLUTIONS

    public void CheckResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int actualResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width 
                && resolutions[i].height == Screen.currentResolution.height)
            {
                actualResolution = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = actualResolution;
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.value = PlayerPrefs.GetInt("resolutionNumber", 0);
    }

    public void ChangeResolution(int indexResolution)
    {
        PlayerPrefs.SetInt("resolutionNumber", resolutionDropdown.value);
        Resolution resolution = resolutions[indexResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
