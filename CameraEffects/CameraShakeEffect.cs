using UnityEngine;
using System.Collections;

public class CameraShakeEffect : MonoBehaviour
{
    public float duration = 2.0f;
    public float magnitude = 0.1f;
    private Camera mainCamera;
    private RenderTexture renderTexture;
    
    void Start()
    {
        mainCamera = Camera.main;
        Debug.Log("Starting render texture shake effect");
        SetupRenderTexture();
        StartCoroutine(ShakeCamera());
    }

    void SetupRenderTexture()
    {
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mainCamera.targetTexture = renderTexture;
    }
    
    private IEnumerator ShakeCamera()
    {
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float xOffset = Random.Range(-1f, 1f) * magnitude;
            float yOffset = Random.Range(-1f, 1f) * magnitude;
            
            Material material = new Material(Shader.Find("Unlit/Texture"));
            material.mainTextureOffset = new Vector2(xOffset, yOffset);

            Graphics.Blit(renderTexture, null, material);
            
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        mainCamera.targetTexture = null;
        Destroy(renderTexture);
        Destroy(gameObject);
    }
}