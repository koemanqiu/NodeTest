using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodeEditorFramework;
using System;

namespace BtNodeEditor
{
    [Node(false, "BT/Control Node", new Type[] { typeof(BtCanvas) })]
    public class ControlNode : BtNodeBase
    {
        public override string Title
        {
            get
            {
                return "Control Node";
            }
        }

        public override Type GetOjbectType
        {
            get
            {
                return typeof(ControlNode);
            }
        }

        //public override Vector2 MinSize
        //{
        //    get
        //    {
        //        return new Vector2(50, 50);
        //    }
        //}

        //public override Vector2 DefaultSize
        //{
        //    get
        //    {
        //        return new Vector2(100, 50);
        //    }
        //}



        private const string Id = "BtControlNode";
        public override string GetID
        {
            get
            {
                return Id;
            }
        }


        [ConnectionKnob("Input Top", Direction.In, "BtIn", NodeSide.Top, 50)]
        public ConnectionKnob fromPreviousIN;
        //[ConnectionKnob("Output Top", Direction.Out, "BtBack", NodeSide.Top,50)]
        //public ConnectionKnob toPreviousOUT;

        [ConnectionKnob("Output Bottom", Direction.Out, "BtOut", NodeSide.Bottom, 50)]
        public ConnectionKnob toNextOUT;
        //[ConnectionKnob("Input Bottom", Direction.In, "BtBack", NodeSide.Bottom, 50)]
        //public ConnectionKnob fromNextIN;

        //private Vector2 scroll;

        protected override void OnCreate()
        {
            //do sth.
            backgroundColor = Color.red;
        }

        public override void NodeGUI()
        {

            EditorGUILayout.LabelField("Control");
        }

        //protected override void DrawNode()
        //{
        //    Rect nodeRect = rect;
        //    nodeRect.position += NodeEditor.curEditorState.zoomPanAdjust + NodeEditor.curEditorState.panOffset;
        //    GUI.Box(nodeRect, GUIContent.none, GUI.skin.box);
        //}

    }
}
