#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;


public class ViewOnly : PropertyAttribute { }

[CustomPropertyDrawer(typeof(ViewOnly))]
public class ViewOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false; // Disable editing
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;  // Re-enable for other fields
    }
}

#endif