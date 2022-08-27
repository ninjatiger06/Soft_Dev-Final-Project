using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public void newGame ()
    {
        SceneManager.LoadScene(1);
    }

    public void loadGame ()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
        Debug.Log(saveString);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
