using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckPoint : MonoBehaviour {
	//prevent player been block at the edge of the ground block
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			Player.autoRun = false;
			Player.m_canDoubleJump = true;
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			Player.autoRun = false;
			Player.m_canDoubleJump = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			Player.autoRun = true;
		}
	}
}
