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

public class WorldSpaceDialogueView : DialogueView
{


#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(WorldSpaceDialogueView))]
[CanEditMultipleObjects]
public class WorldSpaceDialogueViewEditor : Editor
{
#pragma warning disable 0219, 414
	private WorldSpaceDialogueView _sWorldSpaceDialogueView;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sWorldSpaceDialogueView = this.target as WorldSpaceDialogueView;
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
	}
}
#endif