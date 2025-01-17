using UnityEngine;
using UnityEditor;

namespace EditorAttributes.Editor
{
    [CustomPropertyDrawer(typeof(PrefixAttribute))]
    public class PrefixDrawer : PropertyDrawerBase
    {
    	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    	{
            var prefixAttribute = attribute as PrefixAttribute;

			var textSize = GUI.skin.GetStyle("miniLabel").CalcSize(new GUIContent(prefixAttribute.Prefix));

			EditorGUI.PrefixLabel(new Rect(EditorGUIUtility.labelWidth - textSize.x + prefixAttribute.Offset, position.y, position.width, position.height), new GUIContent(prefixAttribute.Prefix), EditorStyles.miniLabel);
		    DrawProperty(position, property, label);
    	}
    }
}
