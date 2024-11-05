using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenDistortionEffect : MonoBehaviour
{
    public float duration = 1.0f;
    public float intensity = 0.1f;
    private RawImage distortionImage;
    private Material distortionMaterial;

    void Start()
    {
        distortionImage = GetComponent<RawImage>();
        distortionMaterial = new Material(Shader.Find("Hidden/DistortionEffect"));
        distortionImage.material = distortionMaterial;
        StartCoroutine(Distort());
    }

    IEnumerator Distort()
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float wave = Mathf.Sin(elapsed * 10) * intensity;
            distortionMaterial.SetFloat("_WaveIntensity", wave);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
