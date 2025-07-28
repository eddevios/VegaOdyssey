using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public string actualLevel;
    private static GlobalVariables _instance;

    public static GlobalVariables Instance
    {
        get
        {
            if (_instance == null)
            {
                // Si no hay una instancia existente, crea una nueva
                GameObject go = new GameObject("GlobalVariables");
                _instance = go.AddComponent<GlobalVariables>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Asegura que solo haya una instancia de GlobalVariables en la escena
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}