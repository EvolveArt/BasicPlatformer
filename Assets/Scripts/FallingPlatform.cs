using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	}

}
