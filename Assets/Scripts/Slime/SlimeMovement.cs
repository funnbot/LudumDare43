using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SlimeHealth))]
public class SlimeMovement : MonoBehaviour
{
    public float Acceleration;
    public float MaxSpeed;
    public Transform CinemaVCam;
    public Animator ModelAnim;

    private Rigidbody rb;
    private SlimeHealth health;
    private Vector3 input;
    private Vector3 savedVelocity;
    private bool inputLocked;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = GetComponent<SlimeHealth>();
    }

    void FixedUpdate()
    {
        if (inputLocked) return;
        Vector3 velocityChange = input * Acceleration;
        velocityChange = CinemaVCam.transform.TransformDirection(velocityChange);
        velocityChange.y = 0;
        rb.AddForce(velocityChange, ForceMode.Force);

        rb.velocity = ClampVelocity(rb.velocity, -MaxSpeed, MaxSpeed);
    }

    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        Vector3 velocity = rb.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        ModelAnim.SetFloat("Velocity", localVelocity.z);

        if (IsMoving())
        {
            velocity.y = 0;
            Vector3 lookAt = velocity + transform.position;
            transform.LookAt(lookAt);

            health.Damage();
        }
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

    public bool IsMoving()
    {
        return rb.velocity.sqrMagnitude > 1;
    }

    private Vector3 ClampVelocity(Vector3 velocity, float min, float max)
    {
        velocity.x = Mathf.Clamp(velocity.x, min, max);
        velocity.z = Mathf.Clamp(velocity.z, min, max);
        return velocity;
    }
}