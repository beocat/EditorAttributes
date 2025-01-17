using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace EditorAttributes
{
	public enum GUIColor
	{
		White,
		Black,
		Gray,
		Red,
		Green,
		Lime,
		Blue,
		Cyan,
		Yellow,
		Orange,
		Brown,
		Magenta,
		Purple,
		Pink,
		UseRGB
	}

	public class ColorFieldAttribute : PropertyAttribute, IColorAttribute
    {
		public float R { get; private set; }
		public float G { get; private set; }
		public float B { get; private set; }
		public string HexColor { get; private set; }

		public GUIColor GUIColor { get; private set; }

		/// <summary>
		/// Attribute to color a field in the inspector
		/// </summary>
		/// <param name="fieldColor">The color of the field</param>
		public ColorFieldAttribute(GUIColor fieldColor) => GUIColor = fieldColor;

		/// <summary>
		/// Attribute to color a field in the inspector
		/// </summary>
		/// <param name="r">Red amount</param>
		/// <param name="g">Green amount</param>
		/// <param name="b">Blue amount</param>
		public ColorFieldAttribute(float r, float g, float b)
		{
			GUIColor = GUIColor.UseRGB;
			R = r;
			G = g;
			B = b;
		}

		/// <summary>
		/// Attribute to color a field in the inspector
		/// </summary>
		/// <param name="hexColor">The color in hexadecimal</param>
		public ColorFieldAttribute(string hexColor) => HexColor = hexColor;
	}
}
