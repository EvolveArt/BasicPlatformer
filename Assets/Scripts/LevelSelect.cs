using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {
    private string levelToLoad;

    public void LOAD_SELECTED_LEVEL(string lvlName)
    {
        levelToLoad = lvlName;
        SceneManager.LoadScene(levelToLoad);
    }
}
