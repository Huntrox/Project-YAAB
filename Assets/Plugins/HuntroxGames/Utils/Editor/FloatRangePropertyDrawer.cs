using UnityEngine;
using UnityEditor;

namespace HuntroxGames.Utils
{
    [CustomPropertyDrawer(typeof(FloatRange))]
    public class FloatRangePropertyDrawer : PropertyDrawer
    {
        private SerializedProperty minValueProp;
        private SerializedProperty maxValueProp;
        bool cache = false;
        string name;
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
            => Screen.width < 333 ? (16f + 18f) : 16f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!cache)
            {
                name = property.displayName;
                property.Next(true);
                minValueProp = property.Copy();
                property.Next(true);
                maxValueProp = property.Copy();
                cache = true;
            }
            Rect contentPosition = EditorGUI.PrefixLabel(position, new GUIContent(name));
            if (position.height > 16f)
            {
                position.height = 16f;
                EditorGUI.indentLevel += 1;
                contentPosition = EditorGUI.IndentedRect(position);
                contentPosition.y += 18f;
            }
            float half = contentPosition.width / 2;
            GUI.skin.label.padding = new RectOffset(6, 3, 6, 6);
            EditorGUIUtility.labelWidth = 32;
            contentPosition.width *= 0.5f;
            EditorGUI.indentLevel = 0;

            EditorGUI.BeginProperty(contentPosition, label, minValueProp);
            {
                EditorGUI.BeginChangeCheck();
                float newVal = EditorGUI.FloatField(contentPosition, new GUIContent("Min"), minValueProp.floatValue);
                if (EditorGUI.EndChangeCheck())
                    minValueProp.floatValue = newVal;
            }
            EditorGUI.EndProperty();

            contentPosition.x += half;

            EditorGUI.BeginProperty(contentPosition, label, maxValueProp);
            {
                EditorGUI.BeginChangeCheck();
                float newVal = EditorGUI.FloatField(contentPosition, new GUIContent("Max"), maxValueProp.floatValue);
                if (EditorGUI.EndChangeCheck())
                    maxValueProp.floatValue = newVal;
            }
            EditorGUI.EndProperty();
        }
    }
}