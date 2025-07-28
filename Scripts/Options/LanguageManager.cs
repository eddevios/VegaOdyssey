using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageManager : MonoBehaviour
{
    private const string LanguageKey = "SelectedLanguage";

    public static void SaveLanguage(string languageCode)
    {
        PlayerPrefs.SetString(LanguageKey, languageCode);
        PlayerPrefs.Save();
    }

    public static string LoadLanguage()
    {
        return PlayerPrefs.GetString(LanguageKey, ""); // Devuelve una cadena vacía si no se encuentra la clave
    }
}
