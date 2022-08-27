using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public Vector3 bulletOffset = new Vector3(0, 1f, 0);

    public Transform firePoint;

    public GameObject bulletPrefab;
    int bulletLayer;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    public AudioSource shooting;

    void Start() {
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update () {
        cooldownTimer -= Time.deltaTime;

        if(Input.GetButton("Fire1") && cooldownTimer <= 0 ) {
            Debug.Log("Pew Pew Cyka");
            shooting.Play();
            // SHOOT!
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            // Creates bullet at this position
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position + bulletOffset, firePoint.rotation);
            bulletGO.layer = bulletLayer;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
      // Destroys bullet upon contact
      Destroy(this);
    }
}
