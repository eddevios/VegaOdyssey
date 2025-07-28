using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Tooltip("Audio Manager")][SerializeField] private AudioManager _audioManager;
    public UnityEvent OnHold;
    bool isHolding;
    float holdStartTime;
    public Image fillImage;
    public string sceneToLoad;
    public string targetFinalScene;
    private void Awake()
    {
        _audioManager = FindFirstObjectByType<AudioManager>();
    }
    void Start()
    {
        fillImage.fillAmount = 0f;
        //sceneToLoad = "Scene_001_MainMenu";
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        holdStartTime = Time.time;
        StartCoroutine(FillImage());
        //print("MANTENGO PULSADO");
        Invoke("CheckHoldTime", 1.1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        //print("BOTON SOLTADO");
        StopCoroutine(FillImage());
        fillImage.fillAmount = 0f;
        CancelInvoke("CheckHoldTime");
    }

    void CheckHoldTime()
    {
        if (isHolding && (Time.time - holdStartTime) >= 1.0f)
        {
            //print("INVOKO!!");
            OnHold.Invoke();
        }
    }
    IEnumerator FillImage()
    {
        while (isHolding)
        {
            float progress = Mathf.Clamp01((Time.time - holdStartTime) / 1.0f);
            fillImage.fillAmount = progress;
            yield return null;
        }
    }

    public void SkipScene()
    {
        print("LA ESCENA A CARGAR ES: " + sceneToLoad);
        if (GlobalVariables.Instance.actualLevel == null)
        {
            GlobalVariables.Instance.actualLevel = "001_MainMenu";
        }
        PlayerPrefs.SetString("SceneToLoad", targetFinalScene);
        //_audioManager.StopMusic();
        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
