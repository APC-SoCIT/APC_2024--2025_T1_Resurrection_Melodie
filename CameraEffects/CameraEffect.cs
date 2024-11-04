using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraEffect : MonoBehaviour
{
    public Image effectImage;
    public float fadeDuration = 1f;

    private void Awake()
    {
        effectImage.gameObject.SetActive(false);
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(0f, 1f));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        effectImage.gameObject.SetActive(true);
        effectImage.color = new Color(effectImage.color.r, effectImage.color.g, effectImage.color.b, startAlpha);
        
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            effectImage.color = new Color(effectImage.color.r, effectImage.color.g, effectImage.color.b, alpha);
            yield return null;
        }

        effectImage.color = new Color(effectImage.color.r, effectImage.color.g, effectImage.color.b, endAlpha);
        if (endAlpha == 0f)
        {
            effectImage.gameObject.SetActive(false);
        }
    }
}
