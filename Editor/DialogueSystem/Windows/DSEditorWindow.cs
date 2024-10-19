using System;
using UnityEditor;
using UnityEngine.UIElements;

public class DSEditorWindow : EditorWindow
{
    [MenuItem("Window/DS/Dialogue Graph")]
    public static void Open()
    {
        GetWindow<DSEditorWindow>("Dialogue Graph");
    }
    private void OnEnable()
    {
        AddGraphView();
        AddStyles();
    }



    private void AddGraphView()
    {
        DSGraphView graphView = new DSGraphView();

        //Stretches the GraphView to be the same size as the DSEditor Window.
        graphView.StretchToParentSize();

        rootVisualElement.Add(graphView);
    }
    private void AddStyles()
    {
        StyleSheet styleSheet = (StyleSheet) EditorGUIUtility.Load("DialogueSystem/DSVariables.uss");

        rootVisualElement.styleSheets.Add(styleSheet);
    }
}
