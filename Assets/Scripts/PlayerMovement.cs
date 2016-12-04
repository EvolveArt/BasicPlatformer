using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	//Public
	public bool onGround = true;
	public float jumpForce = 2f;
	public float speed = 7f;
	public float timeBetweenJumps = 0.5f;
	public bool canJump = true;

	// Private
	private Vector2 movement;
	private Rigidbody2D rb;


	void Awake () {
		rb = GetComponent<Rigidbody2D>();	
	}

	void FixedUpdate () {

		//transform.rotation = new Quaternion (0, 0, 0, 0);

		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.AddForce (new Vector2 (-0.5f, 0f));
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.AddForce (new Vector2 (0.5f, 0f));
		}

		if ( (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.UpArrow) ) && onGround == true && canJump == true) {
			//rb.AddForce (new Vector2 (0f, jumpForce));
			StartCoroutine(Jump(timeBetweenJumps));
		}

	}
		

	IEnumerator Jump(float time) {
		canJump = false;
		rb.AddForce (new Vector2 (0f, jumpForce));
		yield return new WaitForSeconds(time);
		canJump = true;
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Falling Platform" || coll.gameObject.tag == "Platform" || coll.gameObject.tag == "UselessPlatform") {
			onGround = true;
		}
		if (coll.gameObject.tag == "NoJump") {
			onGround = false;
		}
	}

	void OnCollisionExit2D (Collision2D coll) {
		if (coll.gameObject.tag == "Falling Platform" || coll.gameObject.tag == "Platform" || coll.gameObject.tag == "UselessPlatform") {
			onGround = false;
		}
	}
		
}
