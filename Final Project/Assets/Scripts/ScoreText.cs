using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public static int scoreValue = 0;
    static Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    public static void gameFinished ()
    {
        score.text = "Score: " + scoreValue;
        Debug.Log(score.text);
    }
}
