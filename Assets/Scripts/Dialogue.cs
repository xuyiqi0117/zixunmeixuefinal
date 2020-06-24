using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Dialogue : MonoBehaviour {

	public static Flowchart dialogueManager;
	public Flowchart dialogue;
	public string dialogueStr;

	public static bool isTalking {
		get {
			return dialogueManager.GetBooleanVariable ("talking");
		}
	}

	// Use this for initialization
	void Start () {
		dialogueManager = GameObject.Find ("DialogueManager").GetComponent<Flowchart> ();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isTalking) {
			Player.autoRun = false;
		} else if (! isTalking) {
			Player.autoRun = true;
		}	
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			Block targetBlk = dialogue.FindBlock (dialogueStr);
			dialogue.ExecuteBlock (targetBlk);
		}
	}
}
