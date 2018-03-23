using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodeEditorFramework;
using System;

namespace BtNodeEditor
{
    [Node(false, "BT/Root Node", new Type[] { typeof(BtCanvas)})]
    public class BtRootNode : BtNodeBase
    {
        public override string Title
        {
            get
            {
                return "Root Node";
            }
        }

        public override string GetNodeType
        {
            get
            {
                //should return the real class you want to store in the tree
                //just for test;                 
                return GetType().FullName;
            }
        }

        public override Type GetOjbectType
        {
            get
            {
                return typeof(BtRootNode);
            }
        }

        private const string Id = "BtRootNode";
        public override string GetID
        {
            get
            {
                return Id;
            }
        }

        [ConnectionKnob("Output Bottom", Direction.Out, "BtOut", ConnectionCount.Single, NodeSide.Bottom, 50)]
        public ConnectionKnob toNextOUT;

        protected override void OnCreate()
        {
            backgroundColor = Color.magenta;
        }

        public override void NodeGUI()
        {
            EditorGUILayout.LabelField("Root");
        }
    }
}
