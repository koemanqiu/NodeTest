using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

using NodeEditorFramework;

namespace BtNodeEditor
{
    [Node(false, "BT/Decorator Node", new Type[] { typeof(BtCanvas) })]
    public class DecoratorNode : BtNodeBase
    {

        public override string Title
        {
            get
            {
                return "Decorator Node";
            }
        }

        //public override Vector2 DefaultSize
        //{
        //    get
        //    {
        //        return new Vector2(100, 50);
        //    }
        //}

        public override Type GetOjbectType
        {
            get
            {
                return typeof(DecoratorNode);
            }
        }

        private const string Id = "BtDecoratorNode";
        public override string GetID
        {
            get
            {
                return Id;
            }
        }

        [ConnectionKnob("Input Top", Direction.In, "BtIn", NodeSide.Top, 50)]
        public ConnectionKnob fromPreviousIn;

        [ConnectionKnob("Output Bottom", Direction.Out, "BtOut", NodeSide.Bottom, 50)]
        public ConnectionKnob toNextOUT;

        protected override void OnCreate()
        {
            backgroundColor = Color.yellow;
        }

        public override void NodeGUI()
        {
            EditorGUILayout.LabelField("Decorator");
        }

        public override string GetNodeType
        {
            get
            {
                //return "BtNodeEditor.ConditionNode";
                //just for test;
                return GetType().FullName;
            }
        }
    }
}
