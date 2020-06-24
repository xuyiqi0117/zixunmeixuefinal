using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

	private Color color = Color.white;
	// Update is called once per frame
	//J to Red, K to Blue and L to Default
	void Update () {
		HandleColour ();
	}

	void HandleColour() {
		if (Input.GetKeyDown (KeyCode.J)) {
			color = Color.blue;
			ChangeColor (color);
			Player.PlayerColour = Player.BLUE;
		} else if (Input.GetKeyDown (KeyCode.K)) {
			color = Color.red;
			ChangeColor (color);
			Player.PlayerColour = Player.RED;
		} else if (Input.GetKeyDown (KeyCode.L)) {
			color = Color.white;
			ChangeColor (color);
			Player.PlayerColour = Player.DEFAULT;
		}
	}

	//change start colour in practicle system
	void ChangeColor(Color color) {
		ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
		settings.startColor = new ParticleSystem.MinMaxGradient (color);
	}
}
