using UnityEngine;
using TMPro;

public class VersionManager : MonoBehaviour
{

    [SerializeField] public TMP_Text versionText; 
    void Start()
    {
        versionText.text = "VER " + Application.version;
        //Debug.Log("Versión de la aplicación: " + versionText.text);
    }
}