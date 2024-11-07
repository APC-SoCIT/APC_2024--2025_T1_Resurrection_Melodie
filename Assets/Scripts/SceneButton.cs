using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public string sceneName;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadTargetScene);
    }

    void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}