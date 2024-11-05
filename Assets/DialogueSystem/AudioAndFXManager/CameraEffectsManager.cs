using UnityEngine;

public class CameraEffectsManager : MonoBehaviour
{
    private GameObject currentEffect;

    public void ApplyEffect(GameObject effectPrefab)
    {
        // Remove any currently active effect
        if (currentEffect != null)
        {
            Destroy(currentEffect);
        }

        // Instantiate and apply the new effect
        if (effectPrefab != null)
        {
            currentEffect = Instantiate(effectPrefab);
            Debug.Log("Camera effect applied: " + effectPrefab.name);
        }
    }

    public void ClearEffect()
    {
        if (currentEffect != null)
        {
            Destroy(currentEffect);
            currentEffect = null;
            Debug.Log("Camera effect cleared");
        }
    }
}
