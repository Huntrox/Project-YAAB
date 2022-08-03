using UnityEditor;
using UnityEngine;

namespace HuntroxGames.Utils
{
	[CustomPropertyDrawer(typeof(TagAttribute))]
	public class TagAttributeDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
		}
	}
}