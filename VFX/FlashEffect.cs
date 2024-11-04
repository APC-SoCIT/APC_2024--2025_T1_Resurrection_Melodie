using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlashEffect : MonoBehaviour
{
    public float duration = 0.5f;
    public Color flashColor = Color.white;
    private Image flashImage;

    void Start()
    {
        flashImage = GetComponent<Image>();
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float alpha = Mathf.PingPong(elapsed * 2, duration) / duration;
            flashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
