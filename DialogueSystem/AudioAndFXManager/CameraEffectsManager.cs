using UnityEngine;

public class CameraEffectsManager : MonoBehaviour
{
    public void ApplyEffect(GameObject effectPrefab)
    {
        if (effectPrefab != null)
        {
            Debug.Log("Attempting to apply camera effect");
            Instantiate(effectPrefab);
            Debug.Log("Camera effect applied");
        }
    }
}