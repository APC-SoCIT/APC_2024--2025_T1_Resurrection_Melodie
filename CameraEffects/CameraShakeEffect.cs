using UnityEngine;
using System.Collections;

public class CameraShakeEffect : MonoBehaviour
{
    public float duration = 2.0f;
    public float magnitude = 0.1f;
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
        Debug.Log("Starting matrix shake effect");
        StartCoroutine(ShakeCamera());
    }
    
    private IEnumerator ShakeCamera()
    {
        Matrix4x4 originalMatrix = mainCamera.projectionMatrix;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float xOffset = Random.Range(-1f, 1f) * magnitude;
            float yOffset = Random.Range(-1f, 1f) * magnitude;
            
            Matrix4x4 shakeMatrix = Matrix4x4.TRS(new Vector3(xOffset, yOffset, 0), Quaternion.identity, Vector3.one);
            mainCamera.projectionMatrix = originalMatrix * shakeMatrix;
            
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        mainCamera.projectionMatrix = originalMatrix;
        Destroy(gameObject);
    }
}
