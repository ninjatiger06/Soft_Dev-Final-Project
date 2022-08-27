using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneLogic : MovementFull2
{

    //private GameObject player;
    float closeup_range;
    float acceleration_range;
    float desired_goal_ang = 30;
    float attack_range = 30;
    private GameObject player;

    public int score;

    void Start()
    {
     
        player = GetComponent<Rigidbody2D>();
        plane_collider = GetComponent<PolygonCollider2D>();
        maxSpeed = Random.Range(30f, 50f);
        rotSpeed = Random.Range(100, 200);
        fireDelay = Random.Range(0.4f, 1.2f);
        closeup_range = Random.Range(3, 10);
        acceleration_range = Random.Range(20, 35);
        player = GameObject.Find("player");
    }

    protected virtual void Update()
    {

        

        if (player )
        {
            var player_body = player.GetComponent<Rigidbody2D>();
            var playerPos = player_body.transform.position;

            playerPos.y = Mathf.Max(playerPos.y, game.getWaterLevel());

            Vector3 dir = (playerPos - player.transform.position).normalized;

            float goal_ang = Mathf.Atan2(dir.y, dir.x);
            goal_ang = (goal_ang / Mathf.PI) * 180;

            float real_rot = normalizeAngle(player.rotation);
            float real_rot_abs = Mathf.Abs(real_rot);

            float diff = normalizeAngle(goal_ang - player.rotation + 90);
            float diff_abs = Mathf.Abs(diff - 180);

            if (diff_abs > desired_goal_ang)
            {
                if (diff > 0)
                    rotInput = 1;
                else
                    rotInput = -1;
            }
            else
                rotInput = 0;


            float distSqr = (playerPos - player.transform.position).sqrMagnitude;

            if ((distSqr > acceleration_range * acceleration_range && diff_abs < 40) || (player.transform.position.y < (game.getWaterLevel() + 3) && real_rot_abs < 70))
            {
                thrustInput = 1;
            }
            else
            {
                if (distSqr < closeup_range * closeup_range)
                    thrustInput = 1;
                else
                    thrustInput = 0;
            }


            if (diff_abs < 40 && distSqr < attack_range * attack_range)
            {
                Debug.Log("Bam");
            }

        }

    }




    private void FixedUpdate()
    {
        handleMotion();

        /*var update_pos = player.transform.position;
        float old_x = player.transform.position.x;
        update_pos.x = game.calculateLoopingX(update_pos.x);

        float diff_x = old_x - update_pos.x;

        if (Mathf.Abs(diff_x) > 0)
        {
            onTeleported(old_x, update_pos.x);
        }
            

        if (player.transform.position.y < game.levelMins().y)
            update_pos.y = game.levelMins().y;
        if (player.transform.position.y > game.levelMaxs().y)
            update_pos.y = game.levelMaxs().y;

        player.transform.position = update_pos;*/
    }

    protected virtual void LateUpdate()
    {
        var update_pos = player.transform.position;
        float old_x = player.transform.position.x;
        update_pos.x = game.calculateLoopingX(update_pos.x);

        float diff_x = old_x - update_pos.x;

        if (Mathf.Abs(diff_x) > 0)
        {
            onTeleported(old_x, update_pos.x);
        }


        if (player.transform.position.y < game.levelMins().y)
            update_pos.y = game.levelMins().y;
        if (player.transform.position.y > game.levelMaxs().y)
            update_pos.y = game.levelMaxs().y;

        player.transform.position = update_pos;
    }




}
