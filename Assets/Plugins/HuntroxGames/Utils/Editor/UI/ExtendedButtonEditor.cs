using UnityEditor.UI;
using UnityEditor;
using UnityEngine;

namespace HuntroxGames.Utils
{
    
    [CustomEditor(typeof(UI.ExtendedButton), true)]
    [CanEditMultipleObjects]
    public class ExtendedButtonEditor : SelectableEditor
    {

        SerializedObject serialized;
        SerializedProperty m_EnterProperty;
        SerializedProperty m_ExitProperty;
        SerializedProperty m_OnClickProperty;



        protected override void OnEnable()
        {
            base.OnEnable();
            serialized = new SerializedObject(target);
            m_EnterProperty = serializedObject.FindProperty("m_OnEnter");
            m_ExitProperty = serializedObject.FindProperty("m_OnExit");
            m_OnClickProperty = serializedObject.FindProperty("m_OnClick");

        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space();

            serializedObject.Update();


            EditorGUILayout.PropertyField(m_OnClickProperty);
            EditorGUILayout.PropertyField(m_EnterProperty);
            EditorGUILayout.PropertyField(m_ExitProperty);

            EditorGUILayout.Space();



            serializedObject.ApplyModifiedProperties();
        }




    }
}