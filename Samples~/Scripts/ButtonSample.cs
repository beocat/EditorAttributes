using UnityEngine;
using EditorAttributes;

namespace EditorAttributeSamples
{
	[HelpURL("https://editorattributesdocs.readthedocs.io/en/latest/Attributes/button.html")]
	public class ButtonSample : MonoBehaviour
	{
		[Header("Button Attribute:")]
		[SerializeField, Space(-18f), Rename("")] private Void headerHolder;

		[SerializeField] private bool toggleButtons;

		[Button("Button")]
		public void PrintMessage() => print("Hello World!");

		[Button]
		public void ButtonWithParams(string messageToPrint) => print(messageToPrint);

		[Button("Button", 30f)]
		public void TallButton() => print("Tall button");

		[Button(nameof(toggleButtons), ConditionResult.EnableDisable, true)]
		public void ButtonYouCanDisable() => print("Hello World!");

		[Button(nameof(toggleButtons), ConditionResult.ShowHide, true)]
		public void ButtonYouCanHide() => print("Hello World!");
	}
}
