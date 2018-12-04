using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SlimeMovement))]
public class SlimeHealth : MonoBehaviour
{
	private SlimeMovement _slimeMovement;

	[SerializeField] private float _initialSize = 0.5f;

	public float MaxSize = 2f;
	public float DeathSize = 0.2f;

	public float ContinuousDamageMultiplier = 1f;

	public UnityEvent OnDeath;

	public bool Alive_ { get; private set; }

	private void SetScale()
	{
		this.transform.localScale = Vector3.one * this.Size;
	}

	public void Regen()
	{
		this.LerpScale(this.MaxSize);

		this.Alive_ = true;
	}

	private IEnumerator RestartGame()
	{
		yield return new WaitForSecondsRealtime(4f);

		SceneController.Instance.LoadPreviousScene();
	}

	public void Kill()
	{
		this.Alive_ = false;

		this.LerpScale(0.1f);

		this.OnDeath.Invoke();

		this.StartCoroutine(this.RestartGame());
	}

	private float _size;
	public float Size
	{
		get { return this._size; }
		set
		{
			this._size = value;

			if (this._size > this.MaxSize)
				this._size = this.MaxSize;
			else if (this._size <= this.DeathSize)
			{
				this._size = this.DeathSize;

				if (this.Alive_)
					this.Kill();
			}

			this.SetScale();
		}
	}

	[SerializeField] private Vector2 _scalingSpeedRange = new Vector2(1f, 10f);

	private void LerpScale(float scale)
	{
		IEnumerator Lerp(float targetScale)
		{
			float initialScale = this.Size;

			float requiredProgress = Mathf.Abs(targetScale - initialScale);

			float scaleProgress = 0;
			while (scaleProgress < requiredProgress)
			{
				float progressSpeed = Time.deltaTime * Mathf.Clamp(Mathf.Abs(targetScale - initialScale), this._scalingSpeedRange.x, this._scalingSpeedRange.y);

				scaleProgress += progressSpeed;

				this.Size += progressSpeed * ((targetScale - initialScale) < 0 ? -1 : 1);

				if (this.Size >= this.MaxSize)
				{
					break;
				}

				yield return null;
			}
		}

		this.StartCoroutine(Lerp(scale));
	}

	public void Damage()
	{
		if (this.Alive_)
		{
			float healthStep = this.ContinuousDamageMultiplier * Time.deltaTime;

			this.Size -= healthStep;
		}
	}

	private void Awake()
	{
		this.Size = this._initialSize;

		this._slimeMovement = this.GetComponent<SlimeMovement>();

		this.Alive_ = true;
	}
}