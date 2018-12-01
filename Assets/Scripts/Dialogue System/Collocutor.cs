/* Created by Luna.Ticode */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "s Collocutor", menuName = "Storytelling/Collocutor")]
public class Collocutor : ScriptableObject
{
	[SerializeField] private string _profileName;
	public string _ProfileName { get { return this._profileName; } }

	[SerializeField] private Sprite _profileIcon;
	public Sprite _ProfileIcon { get { return this._profileIcon; } }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Collocutor))]
[CanEditMultipleObjects]
public class CollocutorEditor : Editor
{
	private void OnEnable()
	{

	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

#pragma warning disable 0219
		Collocutor sCollocutor = target as Collocutor;
#pragma warning restore 0219
	}
}
#endif