using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.UI;

[CanEditMultipleObjects, CustomEditor(typeof(SceneLoadButton), true)]
public class MyButtonEditor : ButtonEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        this.serializedObject.Update();
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("scene"), true);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("tweenType"), true);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("loadSceneMode"), true);
        this.serializedObject.ApplyModifiedProperties();
    }
}
