using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLevelSelector : MonoBehaviour
{
    public Transform player;
    public Transform level1;
    public Transform level2;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collided With Planet");

        if (player.position.x >= level1.position.x -10 || player.position.x <= level1.position.x + 10) {
            if (player.position.y <= level1.position.y - 10 || player.position.y >= level1.position.y + 10) {
                Debug.Log("Level_1");
            }
        }

        else if (player.position.x >= level2.position.x - 10 || player.position.x <= level2.position.x + 10) {
            if (player.position.y <= level2.position.y - 10 || player.position.y >= level2.position.y + 10) {
                Debug.Log("Level_1");
            }
        }
    }
}
