using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace DS.Windows
{
    using Elements;
    public class DSGraphView : GraphView
    {
        public DSGraphView()
        {
            AddManipulators();
            AddGridBackground();


            AddStyles();
        }


        private void AddManipulators()
        {
            //Use scrollwheel to zoom in and out
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

            this.AddManipulator(CreateNodeContextualMenu());

            //Hold Middle Mouse Button to drag the Dialogue Graph
            this.AddManipulator(new ContentDragger());

            //Allows you to drag the selected nodes selected by the rectangle selector
            this.AddManipulator(new SelectionDragger());

            //Allows you to select multiple nodes by click dragging the mouse
            this.AddManipulator(new RectangleSelector());
        }
        private IManipulator CreateNodeContextualMenu()
        {
            ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
                menuEvent => menuEvent.menu.AppendAction("Add Node", actionEvent => AddElement(CreateNode(actionEvent.eventInfo.localMousePosition)))
            );

            return contextualMenuManipulator;
        }
        private DSNode CreateNode(Vector2 position)
        {
            DSNode node = new DSNode();

            node.Initialize(position);
            node.Draw();

            return node;
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
}