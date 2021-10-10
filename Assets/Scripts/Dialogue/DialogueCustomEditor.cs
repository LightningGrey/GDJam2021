using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogueBox))]
public class DialogueCustomEditor : Editor
{
    SerializedProperty script;
    public override void OnInspectorGUI() {
        serializedObject.Update();
        DialogueBox db = (DialogueBox)target;
        EditorGUILayout.PropertyField(serializedObject.FindProperty("namePlate"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("textDisplay"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("typingSpeed"));


        db.showScript = EditorGUILayout.Foldout(db.showScript, "Script", true);
        if (db.showScript) {
            EditorGUILayout.Space();

            List<Dialogue> script = db.script;
            int size = Mathf.Max(0, EditorGUILayout.IntField("Size", script.Count));

            while (size > script.Count) {
                script.Add(new Dialogue(null));
            }
            while (size < script.Count) {
                script.RemoveAt(script.Count - 1);
            }
            for (int i = 0; i < script.Count; i++) {
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField("Name", GUILayout.MaxWidth(36));
                string name = EditorGUILayout.TextField(script[i].speaker, GUILayout.MaxWidth(60));

                EditorGUILayout.LabelField("Line", GUILayout.MaxWidth(27));
                string line = EditorGUILayout.TextField(script[i].line);

                script[i] = new Dialogue(name, line);

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.Space();
        }


        EditorGUILayout.PropertyField(serializedObject.FindProperty("nextButton"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("sfx"));
        serializedObject.ApplyModifiedProperties();


    }
}
