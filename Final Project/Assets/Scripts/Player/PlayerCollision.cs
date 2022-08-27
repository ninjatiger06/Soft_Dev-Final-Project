using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public Transform respawnPoint;

    Quaternion originalRotation;

    public GameObject cam;

    public int givenZ;

    public int sceneNum;

    public AudioSource explosion;

    public GameOver2 numLives;

    void Start ()
    {
        /*// Creates prefab that can be used across levels
        int lives = PlayerPrefs.GetInt("lives", 3);*/

        // Saves player's original rotation for respawn
        originalRotation = this.gameObject.transform.rotation;

        // Takes the scene number
        sceneNum = SceneManager.GetActiveScene().buildIndex;

        numLives = GameObject.Find("LevelManager").GetComponent<GameOver2>();
    }

    // When something triggers the colliders
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Ship has been hit");

        // Plays explosion sound effect
        explosion.Play();

        // Destroys player
        Destroy(gameObject);

        // Destroys other object only if it is an enemy (won't destroy the ground)
        if (other.tag == "Enemy") {
          Destroy(other.gameObject);
        }

        // Removes a life if the player's been hit
        //numLives.subtractLife();

        //Ends game when player's been hit
        numLives.endGame();

        /*// Recreates prefab with the new number of lives
        int lives = PlayerPrefs.GetInt("lives", numLives);*/

        /*// Turns of the player, moves/rotates them to respawn, turns them back on
        this.gameObject.SetActive(false);

        this.gameObject.transform.position = respawnPoint.position;

        this.gameObject.transform.rotation = originalRotation;

        this.gameObject.SetActive(true);

        // Move camera to player's position
        cam.transform.position = new Vector3(respawnPoint.position.x, respawnPoint.position.y, givenZ);*/

        // Reloads the Scene
        //SceneManager.LoadScene(sceneNum);

        // Turns off time (until player hits a key to move, see MovementFull2)
        Time.timeScale = 0f;
    }
}
