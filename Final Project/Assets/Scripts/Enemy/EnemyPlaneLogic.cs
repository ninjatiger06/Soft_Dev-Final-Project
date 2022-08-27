using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneLogic : MonoBehaviour {


    protected float closeup_range;
    public Rigidbody2D player;
    protected GameObject EnemyShip;
    protected float acceleration_range;
    protected float desired_goal_ang = 30;
    protected float attack_range = 30;
    protected float fireDelay;
    protected float maxSpeed;
    protected float rotSpeed;
    protected float thrustInput;
    protected float rotInput;



    void Start() {

        //maxSpeed = Random.Range(30f, 50f);
        maxSpeed = 60f;
        rotSpeed = Random.Range(100, 200);
        fireDelay = Random.Range(0.4f, 1.2f);
        closeup_range = Random.Range(3, 10);
        acceleration_range = Random.Range(20, 35);
    }

    protected virtual void Update() {


        if (player != null) {

            var EnemyPos = player.transform.position;

            EnemyPos.y = Mathf.Max(EnemyPos.y, -3);

            Vector3 dir = (EnemyPos - player.transform.position).normalized;

            float goal_ang = Mathf.Atan2(dir.y, dir.x);
            goal_ang = (goal_ang / Mathf.PI) * 180;
            Debug.Log(goal_ang);

            float real_rot = normalizeAngle(player.rotation);
            float real_rot_abs = Mathf.Abs(real_rot);

            float diff = normalizeAngle(goal_ang - player.rotation + 90);
            float diff_abs = Mathf.Abs(diff - 180);

            if (diff_abs > desired_goal_ang) {
                if (diff > 0)
                    rotInput = 1;
                else
                    rotInput = -1;
            }
            else
                rotInput = 0;


            float distSqr = (EnemyPos - player.transform.position).sqrMagnitude;

            if ((distSqr > acceleration_range * acceleration_range && diff_abs < 40) || (player.transform.position.y < (0) && real_rot_abs < 70)) {
                thrustInput = 1;
            }
            else {
                if (distSqr < closeup_range * closeup_range)
                    thrustInput = 1;
                else
                    thrustInput = 0;
            }


            if (diff_abs < 40 && distSqr < attack_range * attack_range) {
                Debug.Log("LMAO");
            }

        }



    }

    float normalizeAngle(float ang) {
        ang = (ang + 180) % 360;
        if (ang < 0)
            ang += 360;
        return ang - 180;
    }
}