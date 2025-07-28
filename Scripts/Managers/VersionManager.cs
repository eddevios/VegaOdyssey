using UnityEngine;
using TMPro;

public class VersionManager : MonoBehaviour
{

    [SerializeField] public TMP_Text versionText; 
    void Start()
    {
        versionText.text = "VER " + Application.version;
        //Debug.Log("Versi�n de la aplicaci�n: " + versionText.text);
    }
}