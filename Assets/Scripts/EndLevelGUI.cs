using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndLevelGUI : MonoBehaviour {

	public string levelName = "Next level name";

	public void NEXT_LEVEL () {
		SceneManager.LoadScene (levelName);
		EndTrigger.showGUI = false;
	}

	public void RESTART () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		EndTrigger.showGUI = false;
	}

    public void RETURN_TO_MENU ()
    {
        SceneManager.LoadScene("LevelSelect");
        EndTrigger.showGUI = false;
    }
}
