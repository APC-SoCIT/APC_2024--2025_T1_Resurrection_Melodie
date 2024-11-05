using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float duration = 0.5f;
    public float magnitude = 0.5f;
    private Vector3 originalPosition;
    private float elapsed = 0f;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.position = originalPosition + new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
        }
        else
        {
            transform.position = originalPosition;
            Destroy(gameObject);
        }
    }
}
