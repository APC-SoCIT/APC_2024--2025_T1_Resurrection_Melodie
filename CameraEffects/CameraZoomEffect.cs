using UnityEngine;
using System.Collections;

public class CameraZoomEffect : MonoBehaviour
{
    public float duration = 2.0f;
    public float targetSize = 2.0f; // This will zoom to less than half your current size of 5
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
        Debug.Log("Starting zoom effect with orthographic camera");
        StartCoroutine(ZoomCamera());
    }
    
    private IEnumerator ZoomCamera()
    {
        float startSize = 5f; // Your current camera size
        float elapsed = 0f;
        
        Debug.Log($"Starting Size: {startSize}, Target Size: {targetSize}");
        
        // Zoom in
        while (elapsed < duration)
        {
            float newSize = Mathf.Lerp(startSize, targetSize, elapsed / duration);
            mainCamera.orthographicSize = newSize;
            Debug.Log($"Current Size: {newSize}");
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        yield return new WaitForSeconds(0.5f);
        
        // Zoom out
        elapsed = 0f;
        while (elapsed < duration)
        {
            float newSize = Mathf.Lerp(targetSize, startSize, elapsed / duration);
            mainCamera.orthographicSize = newSize;
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        mainCamera.orthographicSize = startSize;
        Destroy(gameObject);
    }
}
