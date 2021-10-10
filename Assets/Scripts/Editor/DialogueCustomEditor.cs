using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogueManager))]
public class DialogueCustomEditor : Editor
{
    public override void OnInspectorGUI() {
        serializedObject.Update();
        DialogueManager db = (DialogueManager)target;

        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((DialogueManager)target), typeof(DialogueManager), false);
        GUI.enabled = true;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("namePlate"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("textDisplay"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("textBox"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("typingSpeed"));

        db.showScript = EditorGUILayout.Foldout(db.showScript, "Script", true);
        if (db.showScript) {
            EditorGUILayout.Space();
            EditorGUI.indentLevel++;
            List<Dialogue> script = db.script;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Size", GUILayout.MaxWidth(41));
            int size = Mathf.Max(0, EditorGUILayout.IntField(script.Count));
            EditorGUILayout.EndHorizontal();

            while (size > script.Count) {
                script.Add(new Dialogue(null));
            }
            while (size < script.Count) {
                script.RemoveAt(script.Count - 1);
            }
            for (int i = 0; i < script.Count; i++) {
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField("Line", GUILayout.MaxWidth(41));
                string name = EditorGUILayout.TextField(script[i].speaker, GUILayout.MaxWidth(71));
                string line = EditorGUILayout.TextField(script[i].line);

                script[i] = new Dialogue(name, line);

                EditorGUILayout.EndHorizontal();
            }
            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("nextButton"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("sfx"));
        db.volume = EditorGUILayout.Slider("Volume", db.volume, 0.0f, 1.0f);
        serializedObject.ApplyModifiedProperties();
    }
}
