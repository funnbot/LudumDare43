using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesEvent : MonoBehaviour
{
	private Animator _animator;

	public void PlaySound()
	{
		this.GetComponent<AudioSource>().Play();
	}

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

	[SerializeField] private Vector3 _triggerForceAddition = new Vector3(0f, 1f, 0f);
	[SerializeField] private Vector3 _triggerForceMultiplier = new Vector3(2f, 2f, 2f);

	private void OnTriggerEnter(Collider other)
	{
		SlimeHealth slimeHealth = other.GetComponent<SlimeHealth>();
		if (slimeHealth != null)
		{
			slimeHealth.Kill();

			SlimeMovement slimeMovement = slimeHealth.GetComponent<SlimeMovement>();

			slimeMovement.Rigidbody_.AddForce(Vector3.Scale(((other.transform.position - this.transform.position).normalized + this._triggerForceAddition), this._triggerForceMultiplier), ForceMode.Impulse);
		}
	}

	private void Awake()
	{
		this._animator = this.GetComponent<Animator>();
		this._collider = this.GetComponent<Collider>();
	}
}


