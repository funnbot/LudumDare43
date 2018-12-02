using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesEvent : MonoBehaviour
{
	[SerializeField] private float _timeBetweenTriggers = 5f;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent("SlimeController"))
		{
			Controller.Health = -1;
		}
	}
}


