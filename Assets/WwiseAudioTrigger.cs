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
using AK;

[RequireComponent(typeof(AkEvent))]
public class WwiseAudioTrigger : MonoBehaviour
{
	private AkEvent _akEvent;

	public void Trigger(string eventName)
	{
		AkSoundEngine.PostEvent(eventName, this.gameObject);
	}

	public void TriggerById()
	{
		AkSoundEngine.PostEvent(this._akEvent.data.Id, this.gameObject);
	}

	private void Awake()
	{
		this._akEvent = this.GetComponent<AkEvent>();
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}

	private void Reset()
	{
		this._akEvent = this.GetComponent<AkEvent>();

		this._akEvent.triggerList.Clear();
	}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(WwiseAudioTrigger))]
[CanEditMultipleObjects]
public class WwiseAudioTriggerEditor : Editor
{
#pragma warning disable 0219, 414
	private WwiseAudioTrigger _sWwiseAudioTrigger;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sWwiseAudioTrigger = this.target as WwiseAudioTrigger;
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
	}
}
#endif