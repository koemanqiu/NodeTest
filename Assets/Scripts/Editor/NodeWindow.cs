using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using NodeEditorFramework.Standard;

using BtNodeEditor;

public class NodeWindow : EditorWindow
{


    private static NodeEditorWindow _editor;

    [MenuItem("Game Tools/Node Editor")]
    public static NodeEditorWindow OpenNodeEditor()
    { 
        _editor = GetWindow<NodeEditorWindow>();
        _editor.minSize = new Vector2(400, 200);

        NodeEditor.ReInit(false);
        Texture iconTexture = ResourceManager.LoadTexture(EditorGUIUtility.isProSkin ? "Textures/Icon_Dark.png" : "Textures/Icon_Light.png");
        _editor.titleContent = new GUIContent("Node Editor", iconTexture);

        return _editor;
    }

    [MenuItem("Game Tools/Save BtCanvas")]
    public static void SaveBtCanvas()
    {        
        if (NodeEditorWindow.editor != null )
        {
            if (NodeEditorWindow.editor.canvasCache.nodeCanvas.GetType() != typeof(BtNodeEditor.BtCanvas))
            {
                Debug.Log("Can't Save, Not a Bt Canvas");
            }else
            {
                //do sth.
                Debug.Log("Saving...");
                SaveMethod((BtCanvas)NodeEditorWindow.editor.canvasCache.nodeCanvas);
                Debug.Log("Save done.");
            }
        }else
        {
            Debug.Log("Please open Node Editor and Save....");
        }
    }

    static void SaveMethod(BtNodeEditor.BtCanvas bc)
    {
        // Check Nodes and their connection ports
        BtCanvas cav = bc;
        PrintChildren(cav.m_RootNode);
    }

    static void PrintChildren(BtNodeBase node)
    {
        bool hasChildren = false;
        Debug.Log("current is " + node);
        if ( node is BtRootNode)
        {
            if ((node as BtRootNode).toNextOUT != null && (node as BtRootNode).toNextOUT.connections != null)
            {
                for ( int i = 0; i < (node as BtRootNode).toNextOUT.connections.Count; ++i)
                {
                    PrintChildren((node as BtRootNode).toNextOUT.connections[i].body as BtNodeBase);
                }
                //foreach (ConnectionKnob ck in (node as BtRootNode).toNextOUT.connections)
                //{
                //    PrintChildren(ck.body as BtNodeBase);
                //}
            }
        }

        if ( node is ControlNode )
        {
            if ((node as ControlNode).toNextOUT.connections != null)
            {
                List<ConnectionKnob> sortlst = new List<ConnectionKnob>((node as ControlNode).toNextOUT.connections.ToArray()) ;

                sortlst.Sort((x,y) => {
                    return x.body.position.x.CompareTo(y.body.position.x);
                }
                );
                for ( int i = 0; i < sortlst.Count; ++i)
                {
                    PrintChildren(sortlst[i].body as BtNodeBase);
                }

                //foreach (ConnectionKnob ck in (node as ControlNode).toNextOUT.connections)
                //{
                //    PrintChildren(ck.body as BtNodeBase);
                //}
            }
        }

        if ( node is DecoratorNode )
        {
            if ((node as DecoratorNode).toNextOUT.connections != null)
            {
                for ( int i = 0; i < (node as DecoratorNode).toNextOUT.connections.Count; ++i)
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
