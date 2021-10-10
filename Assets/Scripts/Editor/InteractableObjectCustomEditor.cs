using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Interactable), true), CanEditMultipleObjects]
public class InteractableCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}


[CustomEditor(typeof(InteractableObject))]
public class InteractableObjectCustomEditor : InteractableCustomEditor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        InteractableObject io = (InteractableObject)target;

        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((InteractableObject)target), typeof(InteractableObject), false);
        GUI.enabled = true;
        io.interactRange = (Collider2D)EditorGUILayout.ObjectField("Interact Range", io.interactRange, typeof(Collider2D), true);

        io.showScript = EditorGUILayout.Foldout(io.showScript, "Script", true);
        if (io.showScript)
        {
            EditorGUILayout.Space();
            EditorGUI.indentLevel++;
            List<Dialogue> script = io.script;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Size", GUILayout.MaxWidth(41));
            int size = Mathf.Max(0, EditorGUILayout.IntField(script.Count));
            EditorGUILayout.EndHorizontal();

            while (size > script.Count)
            {
                script.Add(new Dialogue(null));
            }
            while (size < script.Count)
            {
                script.RemoveAt(script.Count - 1);
            }
            for (int j = 0; j < script.Count; j++)
            {
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField("Line", GUILayout.MaxWidth(41));
                string name = EditorGUILayout.TextField(script[j].speaker, GUILayout.MaxWidth(71));
                string line = EditorGUILayout.TextField(script[j].line);

                script[j] = new Dialogue(name, line);

                EditorGUILayout.EndHorizontal();
            }
            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
        }

        io.hasOne = EditorGUILayout.Toggle("hasOne", io.hasOne);
        io.onePosition = EditorGUILayout.Vector2Field("onePosition", io.onePosition);
    }
}
