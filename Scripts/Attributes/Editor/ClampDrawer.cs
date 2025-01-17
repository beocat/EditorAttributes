using UnityEngine;
using UnityEditor;

namespace EditorAttributes.Editor
{
    [CustomPropertyDrawer(typeof(ClampAttribute))]
    public class ClampDrawer : PropertyDrawerBase
    {
    	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    	{
			var clampAttribute = attribute as ClampAttribute;

            var minMaxX = (clampAttribute.MinValueX, clampAttribute.MaxValueX);
            var minMaxY = (clampAttribute.MinValueY, clampAttribute.MaxValueY);
            var minMaxZ = (clampAttribute.MinValueZ, clampAttribute.MaxValueZ);
            var minMaxW = (clampAttribute.MinValueW, clampAttribute.MaxValueW);

            switch (property.propertyType)
            {
                case SerializedPropertyType.Integer:
                    property.intValue = (int)Mathf.Clamp(property.intValue, minMaxX.MinValueX, minMaxX.MaxValueX);
                    break;

                case SerializedPropertyType.Float:
					property.floatValue = Mathf.Clamp(property.floatValue, minMaxX.MinValueX, minMaxX.MaxValueX);
					break;

				case SerializedPropertyType.Vector2:
					property.vector2Value = ClampVector(minMaxX, minMaxY, minMaxZ, minMaxW, property.vector2Value);
                    break;

				case SerializedPropertyType.Vector2Int:
                    property.vector2IntValue = Vector3IntToVector2Int(ClampIntVector(minMaxX, minMaxY, minMaxZ, minMaxW, new(property.vector2IntValue.x, property.vector2IntValue.y)));
					break;

				case SerializedPropertyType.Vector3:
					property.vector3Value = ClampVector(minMaxX, minMaxY, minMaxZ, minMaxW, property.vector3Value);
					break;

				case SerializedPropertyType.Vector3Int:
                    property.vector3IntValue = ClampIntVector(minMaxX, minMaxY, minMaxZ, minMaxW, property.vector3IntValue);
					break;

				case SerializedPropertyType.Vector4:
					property.vector4Value = ClampVector(minMaxX, minMaxY, minMaxZ, minMaxW, property.vector4Value);
					break;

				case SerializedPropertyType.Rect:
					property.rectValue = ClampRect(minMaxX, minMaxY, minMaxZ, minMaxW, property.rectValue);
					break;

				case SerializedPropertyType.RectInt:
                    property.rectIntValue = ClampIntRect(minMaxX, minMaxY, minMaxZ, minMaxW, property.rectIntValue);
					break;

				case SerializedPropertyType.Quaternion:
					EditorGUILayout.HelpBox("Quaternions are not supported because they are weird", MessageType.Info);
					break;

				default:
                    EditorGUILayout.HelpBox("The attached field must be numerical", MessageType.Warning);
                    break;
            }

            DrawProperty(position, property, label);
        }

        private Vector4 ClampVector((float, float) minMaxX, (float, float) minMaxY, (float, float) minMaxZ, (float, float) minMaxW, Vector4 vectorValue) 
        {
            ClampAxis(minMaxX, minMaxY, minMaxZ, minMaxW, ref vectorValue);

            return vectorValue;
        }

		private Rect ClampRect((float, float) minMaxX, (float, float) minMaxY, (float, float) minMaxZ, (float, float) minMaxW, Rect rectValue)
		{
			var vector4 = new Vector4(rectValue.x, rectValue.y, rectValue.width, rectValue.height);

			ClampAxis(minMaxX, minMaxY, minMaxZ, minMaxW, ref vector4);

			return new Rect(vector4.x, vector4.y, vector4.z, vector4.w);
		}

		private Vector3Int ClampIntVector((float, float) minMaxX, (float, float) minMaxY, (float, float) minMaxZ, (float, float) minMaxW, Vector3Int vectorValue)
        {
            var vector4 = new Vector4(vectorValue.x, vectorValue.y, vectorValue.z);

			ClampAxis(minMaxX, minMaxY, minMaxZ, minMaxW, ref vector4);

			return new Vector3Int((int)vector4.x, (int)vector4.y, (int)vector4.z);
		}

		private RectInt ClampIntRect((float, float) minMaxX, (float, float) minMaxY, (float, float) minMaxZ, (float, float) minMaxW, RectInt rectValue)
		{
			var vector4 = new Vector4(rectValue.x, rectValue.y, rectValue.width, rectValue.height);

			ClampAxis(minMaxX, minMaxY, minMaxZ, minMaxW, ref vector4);

			return new RectInt((int)vector4.x, (int)vector4.y, (int)vector4.z, (int)vector4.w);
		}

		private void ClampAxis((float, float) minMaxX, (float, float) minMaxY, (float, float) minMaxZ, (float, float) minMaxW, ref Vector4 vector)
        {
            var x = Mathf.Clamp(vector.x, minMaxX.Item1, minMaxX.Item2);
            var y = Mathf.Clamp(vector.y, minMaxY.Item1, minMaxY.Item2);
            var z = Mathf.Clamp(vector.z, minMaxZ.Item1, minMaxZ.Item2);
            var w = Mathf.Clamp(vector.w, minMaxW.Item1, minMaxW.Item2);

            vector = new Vector4(x, y, z, w);
        }

        private Vector2Int Vector3IntToVector2Int(Vector3Int vector3Int) => new(vector3Int.x, vector3Int.y);
	}
}
