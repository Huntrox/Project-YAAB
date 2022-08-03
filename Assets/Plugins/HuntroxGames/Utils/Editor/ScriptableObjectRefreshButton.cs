#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScriptableObject),true)]
[CanEditMultipleObjects]
public class ScriptableObjectRefreshButton : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Refresh/Save"))
        {
            EditorUtility.SetDirty(serializedObject.targetObject);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        EditorGUILayout.HelpBox("Please press the Refresh button after editing the Asset\nMAKE SURE TO DO THAT BEFORE ANY PUSH", MessageType.Warning);
        base.OnInspectorGUI();
    }
    
}
#endif