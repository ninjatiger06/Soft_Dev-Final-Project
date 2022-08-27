using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    public GameObject bulletPrefab;
    int bulletLayer;

    public float fireDelay = 0.50f;
    float cooldownTimer = 0;

    Transform player;

    public Transform firingPoint;


    void Start() {
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update () {

        if(player == null) {
            // Find the player's ship!
            GameObject go = GameObject.FindWithTag("Player");

            if(go != null) {
                player = go.transform;
            }
        }


        cooldownTimer -= Time.deltaTime;

        if( cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4) {
            // SHOOT!
            //Debug.Log ("Enemy Pew!");
            GetComponent<AudioSource>().Play();
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            // Creates a "bullet" object at this position
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firingPoint.position + offset, firingPoint.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
}
