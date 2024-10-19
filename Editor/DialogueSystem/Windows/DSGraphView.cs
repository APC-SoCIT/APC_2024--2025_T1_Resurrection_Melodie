using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace DS.Windows
{
    using Elements;
    using Enumerations;
    public class DSGraphView : GraphView
    {
        public DSGraphView()
        {
            AddManipulators();
            AddGridBackground();


            AddStyles();
        }

#region Overrided Methods
        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            List<Port> compatiblePorts = new List<Port>();
            //Basically allows you to connect each node to the ports.
            ports.ForEach(port =>
            {
                //Used switch case instead of the common If else statement as it would be a lot cleaner and faster.
                switch (true)
                {
                    case bool _ when startPort == port:
                    return;
                    case bool _ when startPort.node == port.node:
                    return;
                    case bool _ when startPort.direction == port.direction:
                    return;
                    default:
                    compatiblePorts.Add(port);
                    break;
                }
            });

            return compatiblePorts;
        }
#endregion

#region Manipulators
        private void AddManipulators()
        {
            //Use scrollwheel to zoom in and out
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

            this.AddManipulator(CreateNodeContextualMenu("Add Single Choice Node)", DSDialogueType.SingleChoice));
            this.AddManipulator(CreateNodeContextualMenu("Add Multiple Choice Node)", DSDialogueType.MultipleChoice));

            //Hold Middle Mouse Button to drag the Dialogue Graph
            this.AddManipulator(new ContentDragger());

            //Allows you to drag the selected nodes selected by the rectangle selector
            this.AddManipulator(new SelectionDragger());

            //Allows you to select multiple nodes by click dragging the mouse
            this.AddManipulator(new RectangleSelector());

            //
            this.AddManipulator(CreateGroupContextualMenu());
        }

        private IManipulator CreateGroupContextualMenu()
        {
            ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
                menuEvent => menuEvent.menu.AppendAction("Add Group", actionEvent => AddElement(CreateGroup("DialogueGroup", actionEvent.eventInfo.localMousePosition)))
            );

            return contextualMenuManipulator;
        }

        private IManipulator CreateNodeContextualMenu(string actionTitle, DSDialogueType dialogueType)
        {
            ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
                menuEvent => menuEvent.menu.AppendAction(actionTitle, actionEvent => AddElement(CreateNode(dialogueType, actionEvent.eventInfo.localMousePosition)))
            );

            return contextualMenuManipulator;
        }
#endregion

#region Elements Creation
         private Group CreateGroup(string title, Vector2 localMousePosition)
        {
            Group group = new Group()
            {
                title = title
            };
            group.SetPosition(new Rect(localMousePosition, Vector2.zero));

            return group;
        }
        private DSNode CreateNode(DSDialogueType dialogueType, Vector2 position)
        {
            Type nodeType = Type.GetType($"DS.Elements.DS{dialogueType}Node");
            DSNode node = (DSNode) Activator.CreateInstance(nodeType);

            node.Initialize(position);
            node.Draw();

            return node;
        }
#endregion

#region Elements Addition
        private void AddGridBackground()
        {
            GridBackground gridBackground = new GridBackground();

            gridBackground.StretchToParentSize();

            Insert(0, gridBackground);
        }
        private void AddStyles()
        {
            StyleSheet graphViewStyleSheet = (StyleSheet) EditorGUIUtility.Load("DialogueSystem/DSGraphViewStyles.uss");
            StyleSheet nodeStyleSheet = (StyleSheet) EditorGUIUtility.Load("DialogueSystem/DSNodeStyles.uss");

            styleSheets.Add(graphViewStyleSheet);
            styleSheets.Add(nodeStyleSheet);

        }
#endregion
    }   
}