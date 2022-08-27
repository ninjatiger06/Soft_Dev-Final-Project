using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public static bool isGameOver = false;

    // Creating player collision object
    public PlayerCollision player1;

    /*
        You're getting this error because it doesn't know what "PlayerCollision"
        is and, if it doesn't know where the PlayerCollision variable is, then
        it doesn't know what value its 'numLives' attribute is storing.

        You need to declare a new PlayerCollision object here:
            public PlayerCollision player1;

        Then, in your Update() function (or, perhaps, a Start() function), you
        define/create a new instance of the PlayerCollision class:
            player1 = new PlayerCollision();

        THEN, after you've made a PlayerCollision object, you can reference its
        attributes, like .numLives.
        It's
    */

    void Start() {
        // Assigning player collision variable
        player1 = new PlayerCollision();
    }

    // Function called once per physics update
    void FixedUpdate() {
        player1 = new PlayerCollision();
        Debug.Log(player1.numLives);    // Logging the number of lives (from PlayerCollision.cs)
        Debug.Log(player1.numLives <= 0);   // Logging if the following If statement should be flagged
        if (player1.numLives <= 0) {    // If the player has run out of lives
            Debug.Log("here");
            gameIsOver();
        }
    }

    public void gameIsOver () {
        isGameOver = true;
        Debug.Log("Game ended.");
    }
}


/*

I've been trying to get the game over condition working, but whenever I try to
reference variables/methods across files, I've only gotten the error:
    error CS0120: An object reference is required for the non-static field,
                  method, or property 'PlayerCollision.numLives'
I honestly can't really decipher it, and what I found online hasn't been helpful.
It also seems that every collision the number of lives decreases by two rather
than one. I've attached the two files.

*/
