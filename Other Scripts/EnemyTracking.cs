using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    //public float rotSpeed = 90f;
    public Transform player;
    public Transform enemyShip;
    public Transform transformRotation;

    void FixedUpdate ()
    {
      if (player == null) {
          GameObject go = GameObject.Find ("playerShip");
          if (go != null) {
              player = go.transform;
          }
      }

        if(player = null) {
            return;
        }

        Vector dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        transformRotation = Quaternion.Euler(0, 0, zAngle);

        enemyShip.transform.Rotate(transformRotation);

        //transform.rotation = Quaternion.RotateTowards( transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }
}
