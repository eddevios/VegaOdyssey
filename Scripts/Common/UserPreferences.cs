using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserPreferences
{
    private const string TermsAcceptedKey = "TermsAccepted";

    // Comprueba si los t�rminos han sido aceptados.
    public static bool AreTermsAccepted()
    {
        return PlayerPrefs.GetInt(TermsAcceptedKey, 0) == 1; // Por defecto no aceptados.
    }

    // Marca los t�rminos como aceptados.
    public static void AcceptTerms()
    {
        PlayerPrefs.SetInt(TermsAcceptedKey, 1);
        PlayerPrefs.Save();
    }

    // Restablece el estado de los t�rminos (opcional, para pruebas o desarrollo).
    public static void ResetTerms()
    {
        PlayerPrefs.SetInt(TermsAcceptedKey, 0);
        PlayerPrefs.Save();
    }
}

