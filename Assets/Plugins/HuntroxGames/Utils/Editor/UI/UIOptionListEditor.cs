using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuntroxGames.Utils.UI;
using UnityEditor;

namespace HuntroxGames.Utils
{
    [CustomEditor(typeof(UIOptionsScrollBar), true)]
    [CanEditMultipleObjects]
    public class UIOptionListEditor : Editor
    {

        SerializedProperty m_CaptionText;
        SerializedProperty m_OnSelectionChanged;
        SerializedProperty m_Value;
        SerializedProperty loop;
        SerializedProperty m_Options;
        SerializedProperty m_NextBtn;
        SerializedProperty m_PreviousBtn;
        void OnEnable()
        {

            m_CaptionText = serializedObject.FindProperty("m_CaptionText");
            m_OnSelectionChanged = serializedObject.FindProperty("m_OnValueChanged");
            m_Value = serializedObject.FindProperty("m_Value");
            m_Options = serializedObject.FindProperty("m_Options");
            m_NextBtn = serializedObject.FindProperty("m_Next");
            m_PreviousBtn = serializedObject.FindProperty("m_Previous");
            loop = serializedObject.FindProperty("loop");
        }

        public override void OnInspectorGUI()
        {
           // base.OnInspectorGUI();
            EditorGUILayout.Space();
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_CaptionText);
            EditorGUILayout.PropertyField(m_NextBtn);
            EditorGUILayout.PropertyField(m_PreviousBtn);
            EditorGUILayout.PropertyField(loop);
            EditorGUILayout.PropertyField(m_Value);
            EditorGUILayout.PropertyField(m_Options);
            EditorGUILayout.PropertyField(m_OnSelectionChanged);
            serializedObject.ApplyModifiedProperties();
        }






    }
}