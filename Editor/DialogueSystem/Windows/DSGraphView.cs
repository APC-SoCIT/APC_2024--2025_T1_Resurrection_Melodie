using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class DSGraphView : GraphView
{
    public DSGraphView()
    {
        AddManipulators();
        AddGridBackground();

        CreateNode();

        AddStyles();
    }

    private void CreateNode()
    {
        DSNode node = new DSNode();

        AddElement(node);
    }

    private void AddManipulators()
    {
        //Use scrollwheel to zoom in and out
        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
        //Hold Middle Mouse Button to drag the Dialogue Graph
        this.AddManipulator(new ContentDragger());
    }
    private void AddGridBackground()
    {
        GridBackground gridBackground = new GridBackground();

        gridBackground.StretchToParentSize();

        Insert(0, gridBackground);
    }
    private void AddStyles()
    {
        StyleSheet styleSheet = (StyleSheet) EditorGUIUtility.Load("DialogueSystem/DSGraphViewStyles.uss");

        styleSheets.Add(styleSheet);
    }
}
