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

        public override Vector2 DefaultSize
        {
            get
            {
                return new Vector2(100, 80);
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

        string m_TreeName = "Tree Name";

        public override void NodeGUI()
        {
            EditorGUILayout.LabelField("Root");

            m_TreeName = GUILayout.TextField(m_TreeName);
            if (GUILayout.Button("Print Tree"))
            {
                PrintTree();
            }
        }

        void PrintTree()
        {
            PrintChildren(this);
        }

        void PrintChildren(BtNodeBase node)
        {
            Debug.Log("current is " + node);
            if (node is BtRootNode)
            {
                if ((node as BtRootNode).toNextOUT != null && (node as BtRootNode).toNextOUT.connections != null)
                {
                    for (int i = 0; i < (node as BtRootNode).toNextOUT.connections.Count; ++i)
                    {
                        PrintChildren((node as BtRootNode).toNextOUT.connections[i].body as BtNodeBase);
                    }
                    //foreach (ConnectionKnob ck in (node as BtRootNode).toNextOUT.connections)
                    //{
                    //    PrintChildren(ck.body as BtNodeBase);
                    //}
                }
            }

            if (node is ControlNode)
            {
                if ((node as ControlNode).toNextOUT.connections != null)
                {
                    List<ConnectionKnob> sortlst = new List<ConnectionKnob>((node as ControlNode).toNextOUT.connections.ToArray());

                    sortlst.Sort((x, y) =>
                    {
                        return x.body.position.x.CompareTo(y.body.position.x);
                    }
                    );
                    for (int i = 0; i < sortlst.Count; ++i)
                    {
                        PrintChildren(sortlst[i].body as BtNodeBase);
                    }

                    //foreach (ConnectionKnob ck in (node as ControlNode).toNextOUT.connections)
                    //{
                    //    PrintChildren(ck.body as BtNodeBase);
                    //}
                }
            }

            if (node is DecoratorNode)
            {
                if ((node as DecoratorNode).toNextOUT.connections != null)
                {
                    for (int i = 0; i < (node as DecoratorNode).toNextOUT.connections.Count; ++i)
                    {
                        PrintChildren((node as DecoratorNode).toNextOUT.connections[i].body as BtNodeBase);
                    }
                    //foreach (ConnectionKnob ck in (node as DecoratorNode).toNextOUT.connections)
                    //{
                    //    PrintChildren(ck.body as BtNodeBase);
                    //}
                }
            }
        }
    }
}
