/* Created by Luna.Ticode */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;

public class SceneController : MonoBehaviourSingleton<SceneController>
{
	[SerializeField] private UnityEventFloat _onLoadingSceneAsync;
	public UnityEventFloat _OnLoadingSceneAsync { get { return this._onLoadingSceneAsync; } }

	private IEnumerator LoadSceneAsyncProcess(int sceneBuildIndex, LoadSceneMode loadSceneMode)
	{
		AsyncOperation sceneLoadingAsyncOperation = SceneManager.LoadSceneAsync(sceneBuildIndex, loadSceneMode);

		while (!sceneLoadingAsyncOperation.isDone)
		{
			this._onLoadingSceneAsync.Invoke(sceneLoadingAsyncOperation.progress);

			yield return null;
		}
	}

	private Coroutine _loadSceneAsyncProcess;

	public void LoadSceneAsync(int sceneBuildIndex, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
	{
		if (this._loadSceneAsyncProcess != null)
			this.StopCoroutine(this._loadSceneAsyncProcess);

		this._loadSceneAsyncProcess = this.StartCoroutine(this.LoadSceneAsyncProcess(sceneBuildIndex, loadSceneMode));
	}

	//! Next
	#region Next
	public void LoadNextScene(LoadSceneMode loadSceneMode = LoadSceneMode.Single)
	{
		int nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;

		if (nextSceneBuildIndex < SceneManager.sceneCountInBuildSettings)
		{
			SceneManager.LoadScene(nextSceneBuildIndex, loadSceneMode);
		}
	}

	public void LoadNextSceneAsync(LoadSceneMode loadSceneMode = LoadSceneMode.Single)
	{
		int nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;

		if (nextSceneBuildIndex < SceneManager.sceneCountInBuildSettings)
		{
			this.LoadSceneAsync(nextSceneBuildIndex, loadSceneMode);
		}
	}
	#endregion

	//! Previous
	#region Previous
	public void LoadPreviousScene(LoadSceneMode loadSceneMode = LoadSceneMode.Single)
	{
		int previousSceneBuildIndex = SceneManager.GetActiveScene().buildIndex - 1;

		if (previousSceneBuildIndex >= 0)
		{
			SceneManager.LoadScene(previousSceneBuildIndex, loadSceneMode);
		}
	}

	public void LoadPreviousSceneAsync(LoadSceneMode loadSceneMode = LoadSceneMode.Single)
	{
		int previousSceneBuildIndex = SceneManager.GetActiveScene().buildIndex - 1;

		if (previousSceneBuildIndex >= 0)
		{
			this.LoadSceneAsync(previousSceneBuildIndex, loadSceneMode);
		}
	}
	#endregion

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

[System.Serializable]
public class UnityEventFloat : UnityEvent<float> { }

#if UNITY_EDITOR
[CustomEditor(typeof(SceneController))]
[CanEditMultipleObjects]
public class SceneControllerEditor : Editor
{
#pragma warning disable 0219, 414
	private SceneController _sSceneController;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sSceneController = this.target as SceneController;
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
	}
}
#endif