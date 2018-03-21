using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using NodeEditorFramework.Standard;

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

}
