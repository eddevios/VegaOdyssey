using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LanguageOptions : MonoBehaviour
{
    [Tooltip("Desplegable con idiomas")][SerializeField] public TMP_Dropdown languageDropdown;
    /*
    void Start()
    {
        if (languageDropdown != null && LocalizationSettings.AvailableLocales.Locales.Count > 0)
        {
            languageDropdown.ClearOptions();

            var options = new List<TMP_Dropdown.OptionData>();

            foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
            {
                options.Add(new TMP_Dropdown.OptionData(locale.name));
            }

            languageDropdown.AddOptions(options);
            languageDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        }
    }
    */
    void Start()
    {
        if (languageDropdown != null && LocalizationSettings.AvailableLocales.Locales.Count > 0)
        {
            languageDropdown.ClearOptions();

            var options = new List<TMP_Dropdown.OptionData>();

            foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
            {
                options.Add(new TMP_Dropdown.OptionData(locale.name));
            }

            languageDropdown.AddOptions(options);

            // Obtener el idioma guardado en PlayerPrefs
            string savedLanguage = LanguageManager.LoadLanguage();

            // Buscar el índice del idioma guardado
            int savedLanguageIndex = LocalizationSettings.AvailableLocales.Locales.FindIndex(l => l.name == savedLanguage);

            // Establecer el índice en el dropdown
            if (savedLanguageIndex != -1)
            {
                languageDropdown.value = savedLanguageIndex;
                languageDropdown.RefreshShownValue(); // Actualizar el texto visible del dropdown
            }

            languageDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        }
    }

    void OnDropdownValueChanged(int index)
    {
        // Obtener el idioma seleccionado
        Locale selectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        LocalizationSettings.SelectedLocale = selectedLocale;
        // Aquí puedes realizar acciones adicionales según el idioma seleccionado
        Debug.Log($"Idioma seleccionado Identifier: {selectedLocale.Identifier}");
        Debug.Log($"Idioma seleccionado: {selectedLocale.name}");
        LanguageManager.SaveLanguage(selectedLocale.name);
    }
}
