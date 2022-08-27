using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFull : MonoBehaviour
{


	public float curThrust = 0;
	private float maxThrust = 1;

	public Rigidbody2D player;

	public float rotInput = 0;
	public float thrustInput = 0;

	public float rotSpeed = 320;

	public float maxSpeed = 40;
	public float acceleration = 10;


	void Update()
	{


		rotInput = Input.GetAxisRaw("Horizontal");
		thrustInput = Input.GetAxisRaw("Vertical");
		// ROTATE the ship.

		// Grab our rotation quaternion
		Quaternion rot = transform.rotation;

		// Grab the Z euler angle
		float z = rot.eulerAngles.z;

		// Change the Z angle based on input
		z -= rotSpeed * GetRotPower() * Time.fixedDeltaTime * rotInput;

		// Recreate the quaternion
		rot = Quaternion.Euler(0, 0, z);

		// Feed the quaternion into our rotation
		transform.rotation = rot;

		// MOVE the ship.
		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3(0, rotSpeed * GetRotPower() * Time.fixedDeltaTime * rotInput, 0);

		pos += rot * velocity;

		if (IsAccelerating())
		{
			curThrust = Mathf.Min(curThrust + 2.3f * Time.fixedDeltaTime, maxThrust);

			player.gravityScale = 0;

			player.AddForce(getAimDir() * 1);
		}

		else
		{
			curThrust = 0;
			player.gravityScale = 0f;
		}

	}



	float GetRotPower()
	{
		if (IsAccelerating())
		{
			return 0.3f;
		}
        else
        {
			return 1f;
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
		Vector3 test = new Vector3(0, 1, 0);
		return test;
	}
}