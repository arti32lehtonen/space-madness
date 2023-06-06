using System;
using System.Linq;
using UnityEditor;
using UnityEngine;


namespace SpaceMadness.Structures
{
    [CustomPropertyDrawer(typeof(NamedList<,>))]
    public class NamedListDrawer : PropertyDrawer
    {
        private static readonly string _valuesAttributeName = "_values";
        private static readonly string _labelsAttributeName = "_enumContainer";

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float totalHeight = EditorGUIUtility.singleLineHeight;
            
            if (property.isExpanded)
            {
                var values = property.FindPropertyRelative(_valuesAttributeName);
                var fields = property.FindPropertyRelative(_labelsAttributeName);
                
                FixArraySize(values, fields);

                for (int i = 0; i < values.arraySize; i++)
                {
                    totalHeight += EditorGUI.GetPropertyHeight(values.GetArrayElementAtIndex(i));
                }
            }
            
            return totalHeight;
        }
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            var foldoutRect = new Rect(
                position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label);

            if (!property.isExpanded)
            {
                return;
            }

            EditorGUI.indentLevel++;
            DrawListContent(position, property);
            EditorGUI.EndProperty();
        }

        private void DrawListContent(Rect position, SerializedProperty property)
        {
            var values = property.FindPropertyRelative(_valuesAttributeName);
            var fields = property.FindPropertyRelative(_labelsAttributeName);
            FixArraySize(values, fields);

            var addYPosition = EditorGUIUtility.singleLineHeight;
            
            for (int i = 0; i < fields.enumNames.Length; i++)
            {
                var ithElement = values.GetArrayElementAtIndex(i);
                var ithField = FixNameUnityStyle(fields.enumNames[i]);
                
                var elementHeight = EditorGUI.GetPropertyHeight(ithElement);
                var elementRect = new Rect(
                    position.x, position.y + addYPosition, position.width, elementHeight);
                addYPosition += elementHeight;
                EditorGUI.PropertyField(
                    elementRect, ithElement, new GUIContent(ithField), true);
            }
        }

        private void FixArraySize(SerializedProperty values, SerializedProperty fields)
        {
            if (values.arraySize != fields.enumNames.Length)
            {
                values.arraySize = fields.enumNames.Length;
            }
        }

        private string FixNameUnityStyle(string inputString)
        {
            return string.Concat(
                inputString.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())
            ).TrimStart(' ');
        }
        
    }
}