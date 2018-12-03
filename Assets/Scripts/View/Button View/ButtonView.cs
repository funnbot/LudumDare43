/* Created by Luna.Ticode */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;

public class ButtonView : InputView
{
	[SerializeField] private UnityEvent _onPointerEnter;
	public override void OnPointerEnter(PointerEventData eventData)
	{
		this._onPointerEnter.Invoke();
	}

	[SerializeField] private UnityEvent _onPointerExit;
	public override void OnPointerExit(PointerEventData eventData)
	{
		this._onPointerExit.Invoke();
	}

	[SerializeField] private UnityEvent _onPointerDown;
	public override void OnPointerDown(PointerEventData eventData)
	{
		this._onPointerDown.Invoke();
	}

	[SerializeField] private UnityEvent _onPointerUp;
	public override void OnPointerUp(PointerEventData eventData)
	{
		this._onPointerUp.Invoke();
	}

	[SerializeField] private UnityEvent _onPointerClick;
	public override void OnPointerClick(PointerEventData eventData)
	{
		this._onPointerClick.Invoke();
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(ButtonView))]
[CanEditMultipleObjects]
public class ButtonViewEditor : Editor
{
#pragma warning disable 0219, 414
	private ButtonView _sButtonView;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sButtonView = this.target as ButtonView;
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
	}
}
#endif