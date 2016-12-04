using UnityEngine;
using System.Collections;

public class TriggerRotation : MonoBehaviour {

    public Animator anim;

	void OnTriggerEnter2D ()
    {
        anim.SetTrigger("PlayerTouch");
    }
}
