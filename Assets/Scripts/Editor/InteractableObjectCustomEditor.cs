using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(Interactable), true)]
//public class InteractableObjectCustomEditor : Editor
//{
//    public override void OnInspectorGUI() {
//        serializedObject.Update();
//        InteractableObject io = (InteractableObject)target;

//        GUI.enabled = false;
//        EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((Interactable)target), typeof(Interactable), false);
//        GUI.enabled = true;

//        EditorGUILayout.PropertyField(serializedObject.FindProperty("interactRange"));

//        io.showScript = EditorGUILayout.Foldout(io.showScript, "Script", true);
//        if (io.showScript) {
//            EditorGUILayout.Space();
//            EditorGUI.indentLevel++;
//            List<Dialogue> script = io.script;
//            EditorGUILayout.BeginHorizontal();
//            EditorGUILayout.LabelField("Size", GUILayout.MaxWidth(41));
//            int size = Mathf.Max(0, EditorGUILayout.IntField(script.Count));
//            EditorGUILayout.EndHorizontal();

//            while (size > script.Count) {
//                script.Add(new Dialogue(null));
//            }
//            while (size < script.Count) {
//                script.RemoveAt(script.Count - 1);
//            }
//            for (int i = 0; i < script.Count; i++) {
//                EditorGUILayout.BeginHorizontal();

//                EditorGUILayout.LabelField("Line", GUILayout.MaxWidth(41));
//                string name = EditorGUILayout.TextField(script[i].speaker, GUILayout.MaxWidth(71));
//                string line = EditorGUILayout.TextField(script[i].line);

//                script[i] = new Dialogue(name, line);

//                EditorGUILayout.EndHorizontal();
//            }
//            EditorGUI.indentLevel--;
//            EditorGUILayout.Space();
//        }
//    }
//}
