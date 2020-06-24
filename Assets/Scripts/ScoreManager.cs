using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;
	public static int bestScore = 0;
	public static float topSpeed = 5;
	//used to track player highest speed before death
	private static float currentSpeed = 0;

	public Text scoreText;
	public Text speedText;
	public Text bestScoreText;
	public Player player;

	public bool isTestSpeed;

	[SerializeField] private float addScoreTime = 1f;
	[SerializeField] private float addScoreCounter;
	// Use this for initialization
	void Start () {
		score = 0;
		addScoreCounter = addScoreTime;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Player.isDead) {
			addScoreCounter -= Time.deltaTime;
			if (addScoreCounter < 0) {
				//mornitor player score
				score++;
				scoreText.text = score.ToString ();
				addScoreCounter = addScoreTime;
			}
			//monitor player speed
			speedText.text = player.m_moveSpeed.ToString ();
			currentSpeed = player.m_moveSpeed;

		//update best score when player had dead
		} else if (Player.isDead) {
			if (!isTestSpeed) {
				if (score > bestScore) {
					bestScore = score;
				}
			} else if (isTestSpeed) {
				if (currentSpeed > topSpeed) {
					topSpeed = currentSpeed;
				}
			}
		}
		//update best score or top speed info
		if (!isTestSpeed) {
			bestScoreText.text = bestScore.ToString ();
		} else if (isTestSpeed) {
			bestScoreText.text = topSpeed.ToString ();
		}
	}
}
