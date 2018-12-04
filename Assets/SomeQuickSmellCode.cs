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

public class SomeQuickSmellCode : MonoBehaviour
{
	public void GoToMainMenu()
	{
		SceneController.Instance.LoadPreviousScene();
	}

	public void LoadNextScene()
	{
		SceneController.Instance.LoadNextScene();
	}

	public void Exit()
	{
		SceneController.Instance.Exit();
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(SomeQuickSmellCode))]
[CanEditMultipleObjects]
public class SomeQuickSmellCodeEditor : Editor
{
#pragma warning disable 0219, 414
	private SomeQuickSmellCode _sSomeQuickSmellCode;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sSomeQuickSmellCode = this.target as SomeQuickSmellCode;
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
	}
}
#endif