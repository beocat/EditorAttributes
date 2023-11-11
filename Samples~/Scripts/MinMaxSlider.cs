using UnityEngine;
using EditorAttributes;

[HelpURL("https://editorattributesdocs.readthedocs.io/en/latest/Attributes/minmaxslider.html")]
public class MinMaxSlider : MonoBehaviour
{
	[Header("MinMaxSlider Attribute:")]
	[SerializeField, MinMaxSlider(-10f, 10f)] private Vector2 vector2Field;
	[SerializeField, MinMaxSlider(-10f, 10f)] private Vector2Int vector2IntField;
	[Space]
	[SerializeField, MinMaxSlider(0f, 10f, false)] private Vector2 vector2FieldNoField;
	[SerializeField, MinMaxSlider(0f, 10f, false)] private Vector2Int vector2IntFieldNoField;
}