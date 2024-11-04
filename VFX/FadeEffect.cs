using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeEffect : MonoBehaviour
{
    public float duration = 1.0f;
    public bool fadeIn = true;
    private Image fadeImage;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float elapsed = 0f;
        float startAlpha = fadeIn ? 1 : 0;
        float endAlpha = fadeIn ? 0 : 1;

        while (elapsed < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
