using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFull2 : MonoBehaviour
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

	Quaternion originalRotation;

    private void Start()
	{
		Time.timeScale = 0f;
		// Saves player's original rotation for respawn
		originalRotation = this.gameObject.transform.rotation;
	}


    void Update()
	{

		rotInput = Input.GetAxisRaw("Horizontal");
		thrustInput = Input.GetAxisRaw("Vertical");
		/*if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
			fireProjectile();
		}*/

		if (rotInput != 0)
		{
			Time.timeScale = 1f;
			var new_rotation = player.rotation - rotSpeed * GetRotPower() * Time.fixedDeltaTime * rotInput;
			new_rotation = normalizeAngle(new_rotation);
			player.MoveRotation(new_rotation);
		}

		if (thrustInput != 0)
		{
			Time.timeScale = 1f;

			curThrust = Mathf.Min(curThrust + 2.3f * Time.fixedDeltaTime, maxThrust);

			player.gravityScale = 0;


			player.AddForce(getAimDir() * acceleration * curThrust / 35, ForceMode2D.Impulse);
		}

		/*if (thrustInput > 0) {
			Time.timeScale = 1f;

			curThrust = Mathf.Min(curThrust + 2.3f * Time.fixedDeltaTime, maxThrust);

			player.gravityScale = 0;

			player.AddForce(getAimDir() * acceleration * curThrust / 35, ForceMode2D.Impulse);
		}

		if (thrustInput < 0) {
			Time.timeScale = 1f;

			curThrust = Mathf.Min(curThrust + 2.3f * Time.fixedDeltaTime, maxThrust) * -1;

			player.gravityScale = 0;

			player.AddForce(getAimDir() * acceleration * curThrust / 35, ForceMode2D.Impulse);
		}*/

		else
		{
			curThrust = 0;
			player.gravityScale = 1.5f;

		}

		var clamped_vel = player.velocity.magnitude;

		clamped_vel = Mathf.Clamp(clamped_vel, 0, maxSpeed);

		player.velocity = getVelDir() * clamped_vel;

		/*if (player.position.x <= -160) {
			player.transform.position = new Vector3(-150, player.position.y, 0);
			thrustInput = 0;
			curThrust = 0;
			this.gameObject.transform.rotation = originalRotation;
		}*/
	}

	/*void fireProjectile()
	{
		if (game.isGamePaused())
		{
			return;
		}

		if (nextFire < Time.time)
		{
			var spawn_pos = player.transform.position + player.transform.up * 2.5f;

			var dir = player.transform.up;
			dir = Quaternion.Euler(0, 0, Random.Range(-4, 4)) * dir;

			game.createProjectile(projectilePrefab, spawn_pos, dir, maxSpeed * 2, 25, player.velocity);

			nextFire = fireDelay + Time.time;
			nextRegen = 0.2f + Time.time;

		}
	}*/




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
