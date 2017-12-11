using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
	Player1 p1;
    Player2 p2;

	// Use this for initialization
	void Start () {
       if (transform.parent.tag == "Player1")
        {
            p1 = GetComponentInParent<Player1>();
        }
        else if (transform.parent.tag == "Player2")
        {
            p2 = GetComponentInParent<Player2>();
        }
    }

	void OnTriggerEnter2D() {
        if (transform.parent.tag == "Player1")
        {
            p1.canJump = true;
        }
        else if (transform.parent.tag == "Player2")
        {
            p2.canJump = true;
        }
	}

	void OnTriggerExit2D() {
        if (transform.parent.tag == "Player1")
        {
            p1.canJump = false;
        }
        else if (transform.parent.tag == "Player2")
        {
            p2.canJump = false;
        }
	}
}
