using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
	Player p;

	// Use this for initialization
	void Start () {
		p = GetComponentInParent<Player> ();
	}

	void OnTriggerEnter2D() {
		p.canJump = true;
	}

	void OnTriggerExit2D() {
		p.canJump = false;
	}
}
