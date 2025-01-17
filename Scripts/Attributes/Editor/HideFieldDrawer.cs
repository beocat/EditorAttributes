using UnityEditor;
using UnityEngine;
using System.Reflection;

namespace EditorAttributes.Editor
{
    [CustomPropertyDrawer(typeof(HideFieldAttribute))]
    public class HideFieldDrawer : PropertyDrawerBase
    {
		private MemberInfo conditionalProperty;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var hideAttribute = attribute as HideFieldAttribute;

			conditionalProperty = GetValidMemberInfo(hideAttribute.ConditionName, property);

			if (!GetConditionValue<HideFieldAttribute>(conditionalProperty, attribute, property.serializedObject.targetObject, true)) DrawProperty(position, property, label);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if (conditionalProperty != null && !GetConditionValue<HideFieldAttribute>(conditionalProperty, attribute, property.serializedObject.targetObject))
			{
				return GetCorrectPropertyHeight(property, label);
			}
			else
			{
				return -EditorGUIUtility.standardVerticalSpacing; // Remove the space for the hidden field
			}
		}
	}
}
