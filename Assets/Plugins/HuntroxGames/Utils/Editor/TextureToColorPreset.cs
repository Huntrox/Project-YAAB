#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
namespace HuntroxGames.Utils
{
    internal static class TextureToColorPreset
    {
        [MenuItem("Assets/Texture To Color Preset")]
        private static void TexToColorPreset()
        {
            var texture = Selection.activeObject as Texture2D;
            if (!texture.isReadable)
            {
                Debug.Log(
                    texture.name + " Is not Readable.\nPlease enable Read/Write on the Texture Advanced Settings!");
                return;
            }
            var cancel = false;
            var height = texture.height;
            var width = texture.width;
            

            if (height > 256 || width > 256)
            {
                if (!EditorUtility.DisplayDialog("Warning",
                    "texture resolution is very high, process might take few minutes\nAre you sure you want to continue",
                    "Yes", "No"))
                    return;
            }
     

            var path = EditorUtility.SaveFilePanel("Texture To Color Preset", "Assets/Editor/", texture.name + " Color Preset",
                "colors");
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
                return;

            
            var alreadyAddedColors = new List<Color>();
            var type = ColorPresetLibraryType();
            var colorPreset = ScriptableObject.CreateInstance(type);
            var presetAddMethod = colorPreset.GetType()
                .GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            path = path.Contains(Application.dataPath + "/")
                ? path.Replace(Application.dataPath + "/", "Assets/")
                : path.Replace(Application.dataPath, "Assets/");
            
            var presetName = Path.GetFileNameWithoutExtension(path);
            var textureColors = texture.GetPixels32();
            var pixelsCount = textureColors.Length;
            var iteration = 0;
           

            if (EditorUtility.DisplayCancelableProgressBar("Creating new color preset",
                $"Pixel {iteration}/{pixelsCount}", (float)iteration /(float) pixelsCount))
            {
                
                cancel = true;
            }
            foreach (Color col in textureColors)
            {
                if (col.a == 0 || alreadyAddedColors.Contains(col))
                    continue;
                alreadyAddedColors.Add(col);
                var param = new object[]
                {
                    (object) col,
                    presetName
                };
                presetAddMethod.Invoke(colorPreset, param);
                iteration ++;
                if (EditorUtility.DisplayCancelableProgressBar("Creating new color preset",
                    $"Pixel {iteration}/{pixelsCount}", (float)iteration /(float) pixelsCount))
                {
                    cancel = true;
                    EditorUtility.ClearProgressBar();
                    break;
                }
            }

            if (cancel)
                return;
            EditorUtility.DisplayProgressBar("Creating new color preset",
                $"Saving",-1);
            AssetDatabase.CreateAsset(colorPreset, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.ClearProgressBar();
            Selection.activeObject = colorPreset;
        }

        [MenuItem("Assets/Texture To Color Preset", true,-1)]
        private static bool TexToColorPresetValidation() => Selection.assetGUIDs.Length > 0 &&
                                                       AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0])
                                                           .Contains(".") && Selection.activeObject is Texture2D;

        private static Type ColorPresetLibraryType()
        {
            return typeof(Editor).Assembly
                .GetType("UnityEditor.ColorPresetLibrary");
        }
    }
}
#endif