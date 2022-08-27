using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMouse : MonoBehaviour
{
    public float speed = 5;
    public float rotationOffset;
    public float delay;
    public float timeDifference;

    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetAxis("Vertical") > 0 && speed < 20)
        {
            speed += 5;
        }
        else if (Input.GetAxis("Vertical") < 0 && speed > 5)
        {
            speed += -5;
        }

        if (Input.GetAxis("Jump") > 0)
        {
            Debug.Log("Boost");
            speed = 30;
            delay = 1f;
            //timeDifference = time.Time
        }

        Debug.Log(transform.position.z);
    }
}
