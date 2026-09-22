using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Lightbug.Utilities
{
    [System.Serializable]
    public class InterfaceField<T> where T : class
    {
        [SerializeField] private UnityEngine.Object value;

        public T Value => value as T;

        public bool IsValid => Value != null;

        public static implicit operator T(InterfaceField<T> field)
        {
            return field?.Value;
        }
    }

#if UNITY_EDITOR


    [CustomPropertyDrawer(typeof(InterfaceField<>), true)]
    public class InterfaceFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var objectProperty = property.FindPropertyRelative("value");

            System.Type interfaceType = fieldInfo.FieldType.GetGenericArguments()[0];

            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.BeginChangeCheck();

            var current = objectProperty.objectReferenceValue;
            var obj = EditorGUI.ObjectField(
                position,
                new GUIContent($"{label}   ({interfaceType.Name})") ,
                current,
                typeof(UnityEngine.Object),
                true);
            
            if (EditorGUI.EndChangeCheck())
            {
                if (obj == null)
                {
                    objectProperty.objectReferenceValue = null;
                }
                else if (interfaceType.IsAssignableFrom(obj.GetType()))
                {
                    objectProperty.objectReferenceValue = obj;
                }
                else if (obj is GameObject go)
                {
                    Component component = go.GetComponent(interfaceType);
                    objectProperty.objectReferenceValue = component;
                    
                    if (component == null)
                        Debug.LogWarning($"{go.name} does not contain any component of type {interfaceType.Name}");
                }
                else
                {
                    Debug.LogWarning($"{obj.GetType().Name} does not implement {interfaceType.Name}");
                    objectProperty.objectReferenceValue = null;
                }
            }

            EditorGUI.EndProperty();
        }
    }

#endif
}