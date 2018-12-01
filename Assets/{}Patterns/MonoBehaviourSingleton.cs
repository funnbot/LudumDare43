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

public class MonoBehaviourSingleton<T> : MonoBehaviour
	where T : MonoBehaviourSingleton<T>
{
	public static T Instance { get; private set; }

	protected virtual void Awake()
	{
		if (Instance == null)
		{
			Instance = this as T;

			Object.DontDestroyOnLoad(Instance.gameObject);
		}
		else if (Instance != this)
		{
			Object.Destroy(Instance.gameObject);
		}
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}