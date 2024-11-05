using UnityEngine;
using UnityEngine.UI;

public class BackgroundDisplay : MonoBehaviour
{
    private Image backgroundImage;

    void Awake()
    {
        backgroundImage = GetComponent<Image>();
    }

    public void SetBackground(Sprite newBackground)
    {
        if (backgroundImage != null)
        {
            backgroundImage.sprite = newBackground;
            //Debug.Log($"Background set to: {newBackground.name}");
        }
    }
}