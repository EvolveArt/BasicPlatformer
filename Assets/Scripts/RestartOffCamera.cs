using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartOffCamera : MonoBehaviour {

	public GameObject target;
	//private Renderer renderer = ;

	// Update is called once per frame
	void Update () {
		if (target.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			print ("Off camera");
		}
	}
}
