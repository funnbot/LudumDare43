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

public static class TransformExtensions
{
	public static void CopyPosition(this Transform transform, Transform otherTransform)
	{
		transform.position = otherTransform.position;
	}

#if UNITY_EDITOR
#endif
}