using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public AudioSource explosion;

    private void OnTriggerEnter2D(Collider2D hitInfo) {
      explosion.Play();
      Destroy(gameObject);
      Destroy(hitInfo.gameObject);
    }

    /*public void die() {
      Debug.Log("Enemy Dying");
      Destroy(gameObject);
    }*/
}
