using UnityEngine;
using EditorAttributes;

namespace EditorAttributeSamples
{
	[HelpURL("https://editorattributesdocs.readthedocs.io/en/latest/Attributes/guicolor.html")]
	public class GUIColorSample : MonoBehaviour
	{
		[Header("GUIColor Attribute:")]
		[GUIColor(GUIColor.Yellow)]
		[SerializeField] private int intField01;
		[SerializeField] private string stringField01;
		[SerializeField] private bool boolField01;
		[Space]
		[GUIColor(3f, 252f, 177f)]
		[SerializeField] private int intField02;
		[SerializeField] private string stringField02;
		[SerializeField] private bool boolField02;
		[Space]
		[GUIColor("#fc0398")]
		[SerializeField] private int intField03;
		[SerializeField] private string stringField03;
		[SerializeField] private bool boolField03;
	}
}
