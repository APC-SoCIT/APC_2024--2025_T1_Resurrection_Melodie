using UnityEngine;
using System.Collections;

public class CameraZoomEffect : MonoBehaviour
{
    public float duration = 2.0f;
    public float targetSize = 131.07f; // Half of your current size for dramatic zoom
    private Camera MainCamera;
    
    void Start()
    {
        MainCamera = Camera.main;
        Debug.Log("Starting zoom effect with new camera settings");
        StartCoroutine(ZoomCamera());
    }
    
    private IEnumerator ZoomCamera()
    {
        float startSize = 262.1434f; // Your current camera size
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float newSize = Mathf.Lerp(startSize, targetSize, elapsed / duration);
            MainCamera.orthographicSize = newSize;
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        yield return new WaitForSeconds(0.5f);
        
        elapsed = 0f;
        while (elapsed < duration)
        {
            float newSize = Mathf.Lerp(targetSize, startSize, elapsed / duration);
            MainCamera.orthographicSize = newSize;
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        MainCamera.orthographicSize = startSize;
        Destroy(gameObject);
    }
}
