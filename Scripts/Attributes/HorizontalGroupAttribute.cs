using UnityEngine;

namespace EditorAttributes
{
    public class HorizontalGroupAttribute : PropertyAttribute
    {
		public float LabelWidth { get; private set; }
		public float FieldWidth { get; private set; }
		public bool DrawInBox { get; private set; }

		public string[] FieldsToGroup { get; private set; }

		/// <summary>
		/// Attribute to display specified fields horizontally
		/// </summary>
		/// <param name="fieldsToGroup">The name of the fields to group</param>
		public HorizontalGroupAttribute(params string[] fieldsToGroup)
		{
			FieldsToGroup = fieldsToGroup;
			DrawInBox = false;
			LabelWidth = 150f;
			FieldWidth = 50f;
		}

		/// <summary>
		/// Attribute to display specified fields horizontally
		/// </summary>
		/// <param name="drawInBox">Draw the group in a nice box</param>
		/// <param name="fieldsToGroup">The name of the fields to group</param>
		public HorizontalGroupAttribute(bool drawInBox, params string[] fieldsToGroup)
		{
			FieldsToGroup = fieldsToGroup;
			DrawInBox = drawInBox;
			LabelWidth = 150f;
			FieldWidth = 50f;
		}

		/// <summary>
		/// Attribute to display specified fields horizontally
		/// </summary>
		/// <param name="labelWidth">The width of the field labels</param>
		/// <param name="fieldWidth">The width of the input fields</param>
		/// <param name="drawInBox">Draw the group in a nice box</param>
		/// <param name="fieldsToGroup">The name of the fields to group</param>
		public HorizontalGroupAttribute(float labelWidth = 150f, float fieldWidth = 50f, bool drawInBox = false, params string[] fieldsToGroup) 
        {
            FieldsToGroup = fieldsToGroup;
			DrawInBox = drawInBox;
			LabelWidth = labelWidth;
            FieldWidth = fieldWidth;
        }
    }
}
