using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorOverlayEffect : MonoBehaviour
{
    public float duration = 1.0f;
    public Color targetColor = new Color(1, 0, 0, 0.5f);
    private Image overlayImage;

    void Start()
    {
        overlayImage = GetComponent<Image>();
        StartCoroutine(ColorFade());
    }

    IEnumerator ColorFade()
    {
        float elapsed = 0f;
        Color startColor = Color.clear;

        while (elapsed < duration)
        {
            overlayImage.color = Color.Lerp(startColor, targetColor, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        yield return new WaitForSeconds(0.5f);
        
        elapsed = 0f;
        while (elapsed < duration)
        {
            overlayImage.color = Color.Lerp(targetColor, startColor, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        Destroy(gameObject);
    }
}
