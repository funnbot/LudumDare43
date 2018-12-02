﻿/* Created by Luna.Ticode */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class LayerMaskExtensions
{
	public static bool Contains(this LayerMask layerMask, int layer)
	{
		return (layerMask & (1 << layer)) > 0;
	}

	public static bool Contains(this LayerMask layerMask, GameObject gameObject)
	{
		return (layerMask & (1 << gameObject.layer)) > 0;
	}

	public static bool Contains(this LayerMask layerMask, Component component)
	{
		return (layerMask & (1 << component.gameObject.layer)) > 0;
	}

	public static bool Contains(this LayerMask layerMask, LayerMask other)
	{
		return (layerMask & other) > 0;
	}
}