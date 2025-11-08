
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

[CustomEditor(typeof(RuleInfo))]
public class RuleInfoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        RuleInfo ruleInfo = (RuleInfo)target;

        // Draw all fields except the function manually
        DrawPropertiesExcluding(serializedObject, "function");

        SerializedProperty functionProp = serializedObject.FindProperty("function");

        EditorGUILayout.Space(10);

        // 🧠 Show the current function name dynamically
        string currentFunctionName = functionProp.managedReferenceValue != null
            ? functionProp.managedReferenceValue.GetType().Name
            : "No Function";

        EditorGUILayout.LabelField($"{currentFunctionName}", EditorStyles.boldLabel);

        // Draw the current function if one is assigned
        if (functionProp.managedReferenceValue != null)
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.PropertyField(functionProp, true);
            EditorGUILayout.EndVertical();
        }
        else
        {
            EditorGUILayout.HelpBox("No function assigned.", MessageType.Info);
        }

        // Dropdown to create or change the function
        if (GUILayout.Button(functionProp.managedReferenceValue == null ? "Add Function" : "Change Function"))
        {
            ShowFunctionMenu(functionProp);
        }

        // Button to remove function
        if (functionProp.managedReferenceValue != null)
        {
            if (GUILayout.Button("Remove Function"))
            {
                functionProp.managedReferenceValue = null;
            }
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void ShowFunctionMenu(SerializedProperty functionProp)
    {
        GenericMenu menu = new GenericMenu();

        Type baseType = typeof(RuleFunction);
        List<Type> types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract)
            .ToList();

        foreach (Type t in types)
        {
            menu.AddItem(new GUIContent(t.Name), false, () =>
            {
                Undo.RecordObject(target, "Assign Card Function");
                functionProp.serializedObject.Update();
                functionProp.managedReferenceValue = Activator.CreateInstance(t);
                functionProp.serializedObject.ApplyModifiedProperties();
            });
        }

        menu.ShowAsContext();
    }
}
