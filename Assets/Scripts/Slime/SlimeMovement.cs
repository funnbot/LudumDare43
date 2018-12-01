﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SlimeMovement : MonoBehaviour
{
    public float Acceleration;
    public Transform CinemaVCam;

    private Rigidbody rb;
    private Vector3 savedVelocity;
    private bool inputLocked;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (inputLocked) return;
        Vector3 input = GetInput() * Acceleration;
        input = CinemaVCam.transform.TransformDirection(input);
        input.y = 0;
        rb.AddForce(input, ForceMode.Acceleration);
    }

    public void SetActive(bool active)
    {
        inputLocked = !active;
        if (active)
        {
            rb.velocity = savedVelocity;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationZ |
                RigidbodyConstraints.FreezeRotationX;
            savedVelocity = rb.velocity;
        }
    }

    private Vector3 GetInput() =>
        new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
}