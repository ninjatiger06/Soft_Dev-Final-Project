using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour {

    public Vector3 shootDir;

    public Transform player;


    private void Update() {
        float moveSpeed = 150f;
        shootDir = transform.position;
        transform.position += shootDir * moveSpeed * Time.deltaTime;


        // Distance based Hit Detection

    }

    /*private void OnTriggerEnter2D(Collider2D collider) {
        // Physics Hit Detection
        Target target = collider.GetComponent<Target>();
        if (target != null) {
            // Hit a Target
            target.Damage();
            Destroy(gameObject);
            Destroy(this);
        }
    }*/

}