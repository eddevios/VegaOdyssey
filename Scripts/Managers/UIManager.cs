using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro livesText;

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }
}