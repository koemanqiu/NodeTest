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

        int i = 0;
        Debug.Log("root is " + cav.m_RootNode);        
        foreach (ConnectionKnob ck in cav.m_RootNode.toNextOut.connections)
        {
            Debug.Log("child is " + ck.body);
        }
    }

}
