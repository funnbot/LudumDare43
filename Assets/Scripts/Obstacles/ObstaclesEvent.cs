using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesEvent : MonoBehaviour
{
	private Animator _animator;

	public void PlayUp()
	{
		this._animator.SetTrigger("Up");
	}

	public void PlayDown()
	{
		this._animator.SetTrigger("Down");
	}

	private Collider _collider;

	public void DisableTriggerCollider()
	{
		this._collider.enabled = false;
	}

	public void EnableTriggerCollider()
	{
		this._collider.enabled = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		SlimeHealth slimeHealth = other.GetComponent<SlimeHealth>();
		if (slimeHealth != null)
		{
			slimeHealth.Diminish();
		}
	}

	private void Awake()
	{
		this._animator = this.GetComponent<Animator>();
		this._collider = this.GetComponent<Collider>();
	}
}


