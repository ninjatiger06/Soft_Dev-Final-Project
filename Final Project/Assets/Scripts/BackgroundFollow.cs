using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 50.0f;
    public float difference = -5;

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + difference, 53, transform.position.z);
    }
}
