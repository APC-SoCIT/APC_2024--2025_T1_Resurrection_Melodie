using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DSEditorWindow : EditorWindow
{
    [MenuItem("Window/UI Toolkit/DSEditorWindow")]
    public static void ShowExample()
    {
        DSEditorWindow wnd = GetWindow<DSEditorWindow>();
        wnd.titleContent = new GUIContent("Dialogue Graph");
    }
}
