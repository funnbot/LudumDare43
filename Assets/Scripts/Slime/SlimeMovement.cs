using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SlimeHealth))]
public class SlimeMovement : MonoBehaviour
{
    public float Acceleration;
	public float MinSpeed = 1f;
    public float MaxSpeed;
    public Transform CinemaVCam;
    public Animator ModelAnim;

    public Rigidbody Rigidbody_ { get; private set; }

	private SlimeHealth health;
    private Vector3 input;
    private Vector3 savedVelocity;
    private bool inputLocked;

    void Start()
    {
        Rigidbody_ = GetComponent<Rigidbody>();
        health = GetComponent<SlimeHealth>();
    }

    void FixedUpdate()
    {
        if (inputLocked) return;
        Vector3 velocityChange = input * Acceleration;
        velocityChange = CinemaVCam.transform.TransformDirection(velocityChange);
        velocityChange.y = 0;

        Rigidbody_.AddForce(velocityChange, ForceMode.Force);

        Rigidbody_.velocity = ClampVelocity(Rigidbody_.velocity, -MaxSpeed, MaxSpeed);
    }

    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        Vector3 velocity = Rigidbody_.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(Rigidbody_.velocity);
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
            Rigidbody_.velocity = savedVelocity;
            Rigidbody_.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            Rigidbody_.constraints = RigidbodyConstraints.FreezeRotationZ |
                RigidbodyConstraints.FreezeRotationX;
            savedVelocity = Rigidbody_.velocity;
            ModelAnim.enabled = true;
        }
    }

    public bool IsMoving()
    {
        return Rigidbody_.velocity.sqrMagnitude > 1;
    }

    private Vector3 ClampVelocity(Vector3 velocity, float min, float max)
    {
		if (input.sqrMagnitude > 0f && velocity.magnitude < this.MinSpeed)
		{
			velocity = input * this.MinSpeed;
		}

		velocity.x = Mathf.Clamp(velocity.x, min, max);
        velocity.z = Mathf.Clamp(velocity.z, min, max);
        return velocity;
    }
}