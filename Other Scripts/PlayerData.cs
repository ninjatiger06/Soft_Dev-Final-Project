using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public int level;
    public int health;
    public float[] position;

    public void collectData (Player player, int level, int health, float[] position)
    {
        level = player.level;
        health = player.health;

       position = new float[3];
       position[0] = player.transform.position.x;
       position[1] = player.transform.position.y;
       position[2] = player.transform.position.z;
    }
}
