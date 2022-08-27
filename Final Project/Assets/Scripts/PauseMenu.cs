using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    //private const string SAVE_SEPARATOR = "#SAVE-VALUE#";

    //public Transform player;

    public int level;

    private void Awake()
    {
      // Checks what the level number is
      level = SceneManager.GetActiveScene().buildIndex;
        /*SaveObject saveObject = new SaveObject
        {
            score = 0,
            level = 1,
        };
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log(json);*/
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

   public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void nextLevel ()
    {
      SceneManager.LoadScene(level + 1);
    }

    public void restartLevel ()
    {
      SceneManager.LoadScene(level);
    }

    public bool isGamePaused()
    {
        return GameIsPaused;
    }

    public int getSceneNum()
    {
      return level;
    }

    /*public void SaveGame ()
    {
        Vector3 playerPosition = player.transform.position;
        //int score = score;

        string[] contents = new string[]
        {
            //""+score,
            ""+level,
            "" + playerPosition.x,
            "" + playerPosition.y
        };
        string saveString = string.Join(SAVE_SEPARATOR, contents);
        File.WriteAllText(Application.dataPath + "/save.txt", saveString);
        Debug.Log("Game Saved");
    }*/

    /*private class SaveObject
    {
        public int score;
        public int level;
    }*/
}
