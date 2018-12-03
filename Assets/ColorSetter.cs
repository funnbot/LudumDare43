/* Created by Luna.Ticode */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;

[RequireComponent(typeof(Graphic))]
public class ColorSetter : MonoBehaviour
{
	private Graphic _graphics;

	[SerializeField] private Color[] _colors;

	public void SetColor(int colorIndex)
	{
		this._graphics.color = this._colors[colorIndex];
	}

	private void Awake()
	{
		this._graphics = this.GetComponent<Graphic>();
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(ColorSetter))]
[CanEditMultipleObjects]
public class ColorSetterEditor : Editor
{
#pragma warning disable 0219, 414
	private ColorSetter _sColorSetter;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sColorSetter = this.target as ColorSetter;
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
	}
}
#endif