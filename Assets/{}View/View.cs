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

[RequireComponent(typeof(Animator), typeof(CanvasGroup))]
public class View : MonoBehaviour
{
	protected RectTransform rectTransform;

	public void Open()
	{
		this.gameObject.SetActive(true);
	}

	public void Close()
	{
		this.gameObject.SetActive(false);
	}

	private Animator _animator;
	private CanvasGroup _canvasGroup;

	public void Show()
	{
		this._animator.SetTrigger("Show");
	}

	public void Hide()
	{
		this._animator.SetTrigger("Hide");
	}

	[SerializeField] private bool _initiallyActive = true;

	protected virtual void Awake()
	{
		this._animator = this.GetComponent<Animator>();
		this._canvasGroup = this.GetComponent<CanvasGroup>();

		this.rectTransform = this.transform as RectTransform;

		if (this._initiallyActive)
		{
			this.Show();
		}
		else
		{
			this.Hide();
		}
	}

#if UNITY_EDITOR
	private void Reset()
	{
		string typeName = this.GetType().Name;
		this.gameObject.name = (string.IsNullOrEmpty(typeName) ? "[View]" : "[View] ") + typeName.Remove(typeName.Length - 4);

		if (this.transform.Find("[Content]") == null)
		{
			GameObject content = new GameObject("[Content]", typeof(RectTransform));

			content.transform.SetParent(this.transform);

			RectTransform contentRectTransform = content.transform as RectTransform;

			contentRectTransform.anchorMin = new Vector2(0f, 0f);
			contentRectTransform.anchorMax = new Vector2(1f, 1f);
			
			contentRectTransform.offsetMin = Vector2.zero;
			contentRectTransform.offsetMax = Vector2.zero;
		}

		if (this.rectTransform == null)
			this.Awake();

		this.rectTransform.anchorMin = new Vector2(0f, 0f);
		this.rectTransform.anchorMax = new Vector2(1f, 1f);

		this.rectTransform.offsetMin = Vector2.zero;
		this.rectTransform.offsetMax = Vector2.zero;
	}

	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(View))]
[CanEditMultipleObjects]
public class ViewEditor : Editor
{
#pragma warning disable 0219, 414
	private View _sView;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sView = this.target as View;
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
	}
}
#endif