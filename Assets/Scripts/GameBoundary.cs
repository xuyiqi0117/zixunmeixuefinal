using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundary : MonoBehaviour {

	[SerializeField] private GameObject targetPlayer;

	void Start() {
		targetPlayer = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (targetPlayer.transform.position.y > Player.LowerLimit) {
			transform.position = new Vector3 (targetPlayer.transform.position.x, 
				targetPlayer.transform.position.y, transform.position.z);
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.CompareTag ("Player")) {
			Player.isDead = true;
		} else {
			Destroy (other.gameObject);
		}
	}
}
