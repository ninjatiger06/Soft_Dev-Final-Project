using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour
{

    public float maxSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Find desired position
        Vector3 pos = transform.position;

        // Speed at which to move to the position
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        // Create the desired position to move to and at what speed
        pos += transform.rotation * velocity;

        // Move to position
        transform.position = pos;
    }
}
