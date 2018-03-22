using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

using NodeEditorFramework;

namespace BtNodeEditor
{
    [Node(false, "BT/Condition Node", new Type[] { typeof(BtCanvas) })]
    public class ConditionNode : BtNodeBase
    {

        public override string Title
        {
            get
            {
                return "Condition Node";
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
                return typeof(ConditionNode);
            }
        }

        private const string Id = "BtConditionNode";
        public override string GetID
        {
            get
            {
                return Id;
            }
        }

        [ConnectionKnob("Input Top", Direction.In, "BtIn", NodeSide.Top, 50)]
        public ConnectionKnob fromPreviousIN;

        protected override void OnCreate()
        {
            backgroundColor = Color.white;
        }

        public override void NodeGUI()
        {
            EditorGUILayout.LabelField("Condition");
        }

    }
}
