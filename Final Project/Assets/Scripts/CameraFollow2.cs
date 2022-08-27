using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 30.0f;
    public int givenZ;

    void Awake ()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, givenZ);

        /*if (player.position.x <= -145) {
          transform.position = new Vector3(-145, player.position.y, givenZ);
        }*/
    }
}
