/* Created by Max.K.Kimo */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;

public class Target : MonoBehaviour
{
	public void CopyPosition(Transform transform)
	{
		this.transform.CopyPosition(transform);
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(Target))]
[CanEditMultipleObjects]
public class TargetEditor : Editor
{
#pragma warning disable 0219, 414
	private Target _sTarget;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sTarget = this.target as Target;
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
	}
}
#endif