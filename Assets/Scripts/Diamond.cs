using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {
	//each diamon worth 10 point
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			ScoreManager.score += 10;
			Destroy (gameObject);
		}
	}
}
