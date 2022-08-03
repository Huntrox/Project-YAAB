using UnityEditor;
using UnityEngine;

namespace HuntroxGames.Utils
{
    [CustomPropertyDrawer(typeof(IntRange))]
    public class IntRangePropertyDrawer : PropertyDrawer
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
                int newVal = EditorGUI.IntField(contentPosition, new GUIContent("Min"), minValueProp.intValue);
                if (EditorGUI.EndChangeCheck())
                    minValueProp.intValue = newVal;
            }
            EditorGUI.EndProperty();

            contentPosition.x += half;

            EditorGUI.BeginProperty(contentPosition, label, maxValueProp);
            {
                EditorGUI.BeginChangeCheck();
                int newVal = EditorGUI.IntField(contentPosition, new GUIContent("Max"), maxValueProp.intValue);
                if (EditorGUI.EndChangeCheck())
                    maxValueProp.intValue = newVal;
            }
            EditorGUI.EndProperty();
        }
    }
}