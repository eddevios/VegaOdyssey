using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("ESTADOS")]
    [Tooltip("Si está pausado")][SerializeField] public bool isPaused;
    [Tooltip("Si el player ha muerto")][SerializeField] public bool isGameOver;
    [Header("REFERENCIAS")]
    [Tooltip("Referencia a la escena Terminos y Condiciones")][SerializeField] public string termsScene;
    [Tooltip("Referencia a la escena MainMenu")][SerializeField] public string mainScene;
    [Tooltip("Referencia a la escena OptionScene")][SerializeField] public string optionScene;
    [Tooltip("Referencia a la cinemática Crash")][SerializeField] public string crashCinematic;
    [Tooltip("Referencia a la cinemática Victory")][SerializeField] public string victoryCinematic;
    [Tooltip("Referencia a la cinemática Ending")][SerializeField] public string endingCinematic;
    [Tooltip("Referencia a la escena GameOver")][SerializeField] public string gameOverScene;
    [Tooltip("Referencia a la escena Creditos")][SerializeField] public string creditsScene;
    [Tooltip("Referencia a la escena Loading")][SerializeField] public string loadingScene;
    [Tooltip("Instancia compartida, referencia al GameManager para acceder desde otros Scripts")][SerializeField] 
    public static GameManager gameManager { get; private set; }
    [Tooltip("Referencia a la escena Creditos")][SerializeField] private string targetScene;
    public enum GameMode { Shooter, Runner }

    [Header("MODO DE JUEGO")]
    [Tooltip("Modo de juego actual")]
    [SerializeField]
    private GameMode currentGameMode = GameMode.Shooter;
    public static event System.Action<GameMode> OnGameModeChanged;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Más de un game manager en escena");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadSettingsPlattforms();
        LoadStates();
    }

    private void Update()
    {
        PauseControl();
    }

    #region Cargar estados
    void LoadStates()
    {
        isPaused = false;
        isGameOver = false;
        Time.timeScale = 1;
    }
    #endregion

    #region Control de Pausa
    void PauseControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("HAS PULSADO ESCAPE");
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    #endregion

    #region Pausa
    public void Pause()
    {
        AudioListener.volume = 0;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
    }
    #endregion

    #region Resume Pause
    public void Resume()
    {
        AudioListener.volume = 1;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }
    #endregion

    #region Gestión del GameMode
    public GameMode CurrentGameMode
    {
        get => currentGameMode;
        set
        {
            if (currentGameMode != value)
            {
                currentGameMode = value;
                OnGameModeChanged?.Invoke(currentGameMode);
            }
        }
    }

    public void SetGameMode(GameMode mode, string associatedScene = null)
    {
        CurrentGameMode = mode;

        if (!string.IsNullOrEmpty(associatedScene))
        {
            LoadNextScene(associatedScene);
        }
    }
    #endregion

    #region Reiniciar Menu
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    #endregion

    #region Volver al Main Menu
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        Invoke("LoadMainMenuScene", 0.5f);
    }
    #endregion

    #region Cargar una escena
    public void LoadNextScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    #endregion

    #region Cargar la escena objetivo
    public void LoadSceneWithLoading(string sceneName)
    {
        targetScene = sceneName;
        SceneManager.LoadScene(loadingScene);
    }
    #endregion

    #region Devuelve la escena objetivo
    public string GetTargetScene()
    {
        return targetScene;
    }
    #endregion

    #region Main Menu
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(mainScene);
    }
    #endregion

    #region Mostrar Creditos
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene(creditsScene);
    }
    #endregion

    #region Game Over
    public void GameOver()
    {
        SceneManager.LoadScene(gameOverScene);
    }
    #endregion

    #region Terms & Conditions
    public void InitializeGameFlow()
    {
        if (UserPreferences.AreTermsAccepted())
        {
            SceneManager.LoadScene(mainScene);
        }
        else
        {
            SceneManager.LoadScene(termsScene);
        }
    }
    #endregion

    #region Plattform
    private void LoadSettingsPlattforms()
    {
        PlatformType platform = PlatformDetector.GetPlatformType();

        switch (platform)
        {
            case PlatformType.Windows:
                Debug.Log("Estás en Windows.");
                Application.targetFrameRate = 60;
                break;

            case PlatformType.macOS:
                Debug.Log("Estás en macOS.");
                Application.targetFrameRate = 60;
                break;

            case PlatformType.Linux:
                Debug.Log("Estás en Linux.");
                Application.targetFrameRate = 60;
                break;

            case PlatformType.Android:
                Debug.Log("Estás en Android.");
                Application.targetFrameRate = 30;
                break;

            case PlatformType.iOS:
                Debug.Log("Estás en iOS.");
                Application.targetFrameRate = 30;
                break;

            case PlatformType.PlayStation:
                Debug.Log("Estás en PlayStation.");
                Application.targetFrameRate = 60;
                break;

            case PlatformType.Xbox:
                Debug.Log("Estás en Xbox.");
                Application.targetFrameRate = 60;
                break;

            case PlatformType.Nintendo:
                Debug.Log("Estás en Nintendo.");
                Application.targetFrameRate = 30;
                break;

            default:
                Debug.Log("No se reconoce la plataforma.");
                break;
        }
    }
    #endregion

    #region Exit App
    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    #endregion
}
