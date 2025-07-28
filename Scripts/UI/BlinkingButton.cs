using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkingButton : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public float fadeInTime = 1.0f;
    public float fadeOutTime = 0.5f;
    void Start()
    {
        // Iniciar la rutina de parpadeo
        StartCoroutine(BlinkRoutine());
    }

    IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // Aparecer durante fadeInTime segundos
            yield return StartCoroutine(FadeIn(buttonText.gameObject, fadeInTime));

            // Desaparecer durante fadeOutTime segundos
            yield return StartCoroutine(FadeOut(buttonText.gameObject, fadeOutTime));
        }
    }

    IEnumerator FadeIn(GameObject obj, float duration)
    {
        float elapsedTime = 0.0f;
        Color originalColor = obj.GetComponent<TextMeshProUGUI>().color;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(0.0f, 1.0f, elapsedTime / duration);
            obj.GetComponent<TextMeshProUGUI>().color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.GetComponent<TextMeshProUGUI>().color = originalColor;
    }

    IEnumerator FadeOut(GameObject obj, float duration)
    {
        float elapsedTime = 0.0f;
        Color originalColor = obj.GetComponent<TextMeshProUGUI>().color;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / duration);
            obj.GetComponent<TextMeshProUGUI>().color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.GetComponent<TextMeshProUGUI>().color = originalColor;
    }
}
