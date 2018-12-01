using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SlimeMovement : MonoBehaviour
{
    // Essentially just a marble controller

    public float MovementSpeed;
    public float Decceleration;

    private Rigidbody rb;
    private float savedVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void Update()
    {

    }

    public void SetActive(bool active)
    {
        if (active)
        {
            
        }
    }

    private void GetInput()
    {

    }
}