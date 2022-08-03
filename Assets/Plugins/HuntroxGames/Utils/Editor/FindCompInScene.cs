#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace HuntroxGames.Utils
{
    public static class FindCompInScene
    {
        [MenuItem("Assets/Find In Scene")]
        private static void FindInScene()
            => SetSearchFilter(Selection.activeObject.name,
                AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]).Contains(".cs") ? 2 : 0);

        [MenuItem("Assets/Find In Scene", true)]
        private static bool FindInSceneValidation() => Selection.assetGUIDs.Length > 0 &&
            AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]).Contains(".");
        
        [MenuItem("CONTEXT/Component/Find In Scene")]
        private static void FindInSceneContextMenu(MenuCommand command)
        {
            Component component = (Component) command.context;
            SetSearchFilter(component.GetType().Name, 2);
        }

        public static void SetSearchFilter(string filter, int filterMode)
        {
            var hierarchy = GetSearchableWindows();
            if (hierarchy == null) return;
            MethodInfo setSearchType = typeof(SearchableEditorWindow).GetMethod("SetSearchFilter",
                BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = new object[] {
                filter,//string searchFilter
                filterMode,//SearchableEditorWindow.SearchMode mode
                false,//bool setAll
                false};//bool delayed
            setSearchType.Invoke(hierarchy, parameters);
        }
        
        
        public static SearchableEditorWindow GetSearchableWindows()
        {
            List<SearchableEditorWindow> searchableWindows = new List<SearchableEditorWindow>();
            var type = typeof(SearchableEditorWindow);
            var fields =
                GetFieldsOfType<List<SearchableEditorWindow>>(type, BindingFlags.Static | BindingFlags.NonPublic);
        
        
            foreach (var field in fields)
            {
                foreach (var searchableWindow in field)
                {
                    HierarchyType hierarchyType = GetInstanceField<HierarchyType>(searchableWindow, "m_HierarchyType");
                    if (searchableWindow.GetType().ToString() == "UnityEditor.SceneHierarchyWindow" 
                        && hierarchyType == HierarchyType.GameObjects)
                    {
                        return searchableWindow;
                    }
                }
                    
            }
            return null;
        }
        
        public static IEnumerable<T> GetFieldsOfType<T>(Type type,BindingFlags flags)
        {
            return type.GetFields(flags)
                .Where(f => f.FieldType == typeof(T))
                .Select(f => f.GetValue(type)).Cast<T>();
        }
        public static T GetInstanceField<T>(object instance, string fieldName)
        {
            var type = instance.GetType();
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                                     | BindingFlags.Static;
            return (T)type.GetField(fieldName, flags)?.GetValue(instance);
        }
    }
}
#endif