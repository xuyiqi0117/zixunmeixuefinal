using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public Player player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			if (player.m_moveSpeed > 4) {
				player.m_moveSpeed -= 3;
			}
			Destroy (gameObject);
		}
	}
}
