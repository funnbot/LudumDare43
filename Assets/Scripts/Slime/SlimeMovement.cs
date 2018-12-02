using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SlimeMovement : MonoBehaviour
{
    public float Acceleration;
    public Transform CinemaVCam;
    public Animator ModelAnim;

    private Rigidbody rb;
    private Vector3 input;
    private Vector3 savedVelocity;
    private bool inputLocked;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (inputLocked) return;
        Vector3 velocityChange = input * Acceleration;
        velocityChange = CinemaVCam.transform.TransformDirection(velocityChange );
        velocityChange .y = 0;
        rb.AddForce(velocityChange , ForceMode.Acceleration);
    }

    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        Vector3 velocity = transform.InverseTransformDirection(rb.velocity);
        ModelAnim.SetFloat("Velocity", velocity.z);

        Vector3 lookAt = new Vector3(input.x, 0, input.z) + transform.position;
        transform.LookAt(lookAt);
    }

    public void SetActive(bool active)
    {
        inputLocked = !active;
        if (active)
        {
            ModelAnim.enabled = false;
            rb.velocity = savedVelocity;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationZ |
                RigidbodyConstraints.FreezeRotationX;
            savedVelocity = rb.velocity;
            ModelAnim.enabled = true;
        }
    }
}