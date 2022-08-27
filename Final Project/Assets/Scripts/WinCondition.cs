using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    public int numEnemies;
    public static int score = 0;
    public string scoreText;
    public GameObject gameWonUI;
    bool gameisOver = false;
    public List<GameObject> enemies = new List<GameObject>();

    // Update is called once per frame
    void FixedUpdate() {
      Debug.Log(numEnemies);
      // Check if there are any enemies left. If not, game is won.
      if (numEnemies <= 0) {
        gameWon();
      }
      else if (Input.GetButton("Fire2"))
          for (int i = 0; i < enemies.Count; i++)
          {
                if (enemies[i] != null)
                {
                    Destroy(enemies[i]);
                    subtract();
                    addScore(100);
                }
          }
    }

    public int subtract() {
      if (numEnemies == 0) {
        // If there are no enemies left, 0 is returned
        return 0;
      }
      else {
        // Subtracts an enemy from the total;
        numEnemies -= 1;
        return numEnemies;
      }
    }

    public int addScore(int scoreToAdd) {
      // Adds the given input from the enemy type to the score
      score += scoreToAdd;
      //ScoreText.scoreValue = score;
      return score;
    }

    public int checkScore() {
      return score;
    }

    void gameWon () {
      // Turning off time
      Time.timeScale = 0f;

      //ScoreText.gameFinished();
      //Debug.Log("ScoreText.gameFinished()");
      Debug.Log("Game Won");
      gameisOver = true;

      Debug.Log("Score: " + score);

      // Showing the gameWon UI
      gameWonUI.SetActive(true);
    }
}
