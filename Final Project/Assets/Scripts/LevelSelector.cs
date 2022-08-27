using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public Button[] levelButtons;

    int levelReached = PlayerPrefs.GetInt("levelReached", 1);

    void Start () {

        for (int i = 0; i < levelButtons.Length; i++) {
            if (i + 1 > levelReached) {
                levelButtons[i].interactable = false;
            }

        }
    }

    public void Select (int levelNum) {
        Debug.Log("Button Pressed");
        SceneManager.LoadScene(levelNum+1);
    }

    public void mainMenu() {
        SceneManager.LoadScene(0);
    }
}
