using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColour : MonoBehaviour {

	public enum ItemColor {RED, BLUE, DEFAULT};
	public ItemColor myColor;
	public int checkColour;

	// Use this for initialization
	void Start () {
		initCheckColour ();
	}

	//destory player when groud color is different with player's color
	void OnCollisionStay(Collision other) {
		if (other.gameObject.CompareTag ("Player")) {
			if (checkColour != Player.PlayerColour) {
				Player.isDead = true;
			}
		}
	}

	//check ground block has same colour with player
	private void initCheckColour () {
		if (myColor == ItemColor.RED) {
			checkColour = Player.RED;
		} else if (myColor == ItemColor.BLUE) {
			checkColour = Player.BLUE;
		} else if (myColor == ItemColor.DEFAULT) {
			checkColour = Player.DEFAULT;
		}
	}
}
