using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{
	public GameObject game;

	public float curThrust = 0;
	private float maxThrust = 1;

	public Rigidbody2D player;

	public float rotInput = 0;
	public float thrustInput = 0;

	public float rotSpeed = 320;

	float rotationAngle = 0;

	public float maxSpeed = 1;
	public float acceleration = 0.1f;
	float nextFire = 0;
	float fireDelay = 0.11f;


	void Update()
	{

		rotInput = Input.GetAxisRaw("Horizontal");
		thrustInput = Input.GetAxisRaw("Vertical");

		if (rotInput != 0)
		{
			var new_rotation = player.rotation - rotSpeed * GetRotPower() * Time.fixedDeltaTime * rotInput;
			new_rotation = normalizeAngle(new_rotation);
			player.MoveRotation(new_rotation);
		}



		if (thrustInput != 0)
		{
			curThrust = Mathf.Min(curThrust + 2.3f * Time.fixedDeltaTime, maxThrust);

			player.gravityScale = 0;


			player.AddForce(getAimDir() * acceleration * curThrust / 35, ForceMode2D.Impulse);
		}

		else
		{
			curThrust = 0;
			player.gravityScale = 0f;

		}

		var clamped_vel = player.velocity.magnitude;

		clamped_vel = Mathf.Clamp(clamped_vel, 0, maxSpeed);

		player.velocity = getVelDir() * clamped_vel;
	}

	float GetRotPower()
	{
		if (IsAccelerating())
		{
			return 0.5f;
		}
		else
		{
			return 1.4f;
		}
	}

	bool IsAccelerating()
	{
		return thrustInput > 0;
	}

	Vector2 getVelDir()
	{
		return player.velocity.normalized;
	}

	Vector2 getAimDir()
	{
		return player.transform.right;
	}

	float normalizeAngle(float ang)
	{
		ang = (ang + 180) % 360;
		if (ang < 0)
			ang += 360;
		return ang - 180;
	}
}