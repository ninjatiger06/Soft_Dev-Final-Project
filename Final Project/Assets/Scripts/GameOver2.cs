using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver2 : MonoBehaviour
{
    private bool gameEnded = false;
    public GameObject gameOverUI;
    public int numLives = 3;

    // Start is called before the first frame update
    public void FixedUpdate() {
        if (gameEnded)
            endGame();
    }

    public int subtractLife() {
      // Checks to see if there are no lives left, if so, the game is over
      if (numLives == 0) {
        endGame();
        return 0;
      }
      else {
        // If there are still lives left, 1 is subtracted from the total.
        numLives -= 1;
        Debug.Log(numLives);
        return numLives;
      }
    }

    // Update is called once per frame
    public void endGame() {
        gameEnded = true;

        //ScoreText.gameFinished();
        //Debug.Log("ScoreText.gameFinished()");

        Debug.Log("Score: " + WinCondition.score);

        // Time is turned off
        Time.timeScale = 0f;

        // Game over screen is shown
        gameOverUI.SetActive(true);
    }
}
