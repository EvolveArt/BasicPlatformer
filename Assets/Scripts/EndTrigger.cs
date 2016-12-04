using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour {

	public static bool showGUI = false;
	public GameObject canvas;


	void Start () {
		canvas = GameObject.Find ("EndLevel");
	}

	void OnTriggerEnter2D (Collider2D other) {
		showGUI = true;
	}

	void Update () {
		
		// Arret du temps & Affichage du GUI
		if (showGUI) {
			canvas.SetActive (true);
			Time.timeScale = 0;
		} else {
			canvas.SetActive (false);
			Time.timeScale = 1;
		}

	}
		
}
