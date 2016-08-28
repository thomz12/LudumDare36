using UnityEngine;
using UnityEditor;
using System.Collections;

class cDebug : EditorWindow
{
    [MenuItem("Window/cDebug")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(cDebug));
    }

    public float Tech = 0f;

    void OnGUI()
    {
        GUILayout.Label("Tech Points Debug Menu", EditorStyles.boldLabel);
        Tech = EditorGUILayout.FloatField("Tech Points", Tech);
        if (GUILayout.Button("Change tech with value"))
        {
            GameManager.Instance.setTech((int)(Tech*10));
        }
    }
}