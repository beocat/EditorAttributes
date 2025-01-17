using UnityEngine;
using EditorAttributes;

namespace EditorAttributeSamples
{
	[HelpURL("https://editorattributesdocs.readthedocs.io/en/latest/Attributes/suffix.html")]
	public class SuffixSample : MonoBehaviour
	{
		[Header("Suffix Attribute:")]
		[SerializeField, Suffix("meters")] private float intField;
		[SerializeField, Suffix("km", 30f)] private float floatField;
	}
}
