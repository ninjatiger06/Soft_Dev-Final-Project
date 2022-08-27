using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 3000000f;
    public Rigidbody2D rb;
    public WinCondition numEnemies;
    public WinCondition score;

    // Start is called before the first frame update
    void Start() {
        // Creates the bullet's speed
        rb.velocity = transform.right * speed;
        numEnemies = GameObject.Find("LevelManager").GetComponent<WinCondition>();
        score = GameObject.Find("LevelManager").GetComponent<WinCondition>();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
      EnemyCollision enemy = hitInfo.GetComponent<EnemyCollision>();
      Debug.Log(hitInfo.tag);
      if (hitInfo.tag == "Enemy") {
        Debug.Log("Enemy hit");
        // If there is a hit, the number of enemies goes down by 1
        numEnemies.subtract();
        score.addScore(100);

        // Removes the target
        Destroy(hitInfo.gameObject);
      }

      // Removes the bullet
      Destroy(gameObject);
    }
}
