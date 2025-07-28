using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserPreferences
{
    private const string TermsAcceptedKey = "TermsAccepted";

    // Comprueba si los términos han sido aceptados.
    public static bool AreTermsAccepted()
    {
        return PlayerPrefs.GetInt(TermsAcceptedKey, 0) == 1; // Por defecto no aceptados.
    }

    // Marca los términos como aceptados.
    public static void AcceptTerms()
    {
        PlayerPrefs.SetInt(TermsAcceptedKey, 1);
        PlayerPrefs.Save();
    }

    // Restablece el estado de los términos (opcional, para pruebas o desarrollo).
    public static void ResetTerms()
    {
        PlayerPrefs.SetInt(TermsAcceptedKey, 0);
        PlayerPrefs.Save();
    }
}

