using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ShowReferenceTypeNameAttribute : PropertyAttribute { }

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(ShowReferenceTypeNameAttribute))]
public class ShowReferenceTypeNameAttributeEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.objectReferenceValue)
        {
            var itemName = property.objectReferenceValue.GetType().Name;
            EditorGUI.PropertyField(position, property, new GUIContent($"{label} ({itemName})"));
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }        
    }
}

#endif
