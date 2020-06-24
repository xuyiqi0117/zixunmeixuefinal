using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player : MonoBehaviour {

	public float m_moveSpeed;
    [SerializeField] private float m_jumpForce;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

	[SerializeField] public static bool autoRun = true;
	[SerializeField] public static bool autoIncreaseSpeed = true;
	[SerializeField] public static bool m_canDoubleJump = true;//check double jump
    private List<Collider> m_collisions = new List<Collider>();
    private bool m_isGrounded;

	//param used to auto increase player's speed
	[SerializeField] private float timeToIncreaseSpeed;
	private float timeToIncreaseSpeedCounter;

	public static int RED = 1;
	public static int BLUE = 2;
	public static int DEFAULT = 3;

	public static int PlayerColour {
		get;
		set;
	}

	//decide player is on low generate point
	public static bool OnLowGenPot {
		get;
		set;
	}

	//set player lower limit to fall
	public int lowerLimit;
	public static float LowerLimit {
		get;
		private set;
	}

	//use a praticle system object to handle player's dead animation
	private float dieTime = 1f;
	public GameObject deadExplosion;
	public static bool isDead {
		get;
		set;
	}

	//delay dead based on dead time
	private IEnumerator Dead() {
		yield return new WaitForSeconds (dieTime);
		gameObject.SetActive (false);
		yield return 0;
	}

	private void HandleDead() {
		if (isDead) {
			deadExplosion.SetActive (true);
			m_animator.SetFloat ("vSpeed", 0);
			m_moveSpeed = 0;
			//StartCoroutine (Dead ());
			dieTime -= Time.deltaTime;
			if (dieTime < 0f) {
				gameObject.SetActive (false);
			}
		}
	}

	private void Start () {
		m_animator = GetComponent<Animator> ();
		m_rigidBody = GetComponent<Rigidbody> ();
		timeToIncreaseSpeedCounter = timeToIncreaseSpeed;
		Player.LowerLimit = this.lowerLimit;
		Player.isDead = false;
		Player.PlayerColour = DEFAULT;
		Player.autoRun = true;
	}

	void Update () {
		m_animator.SetBool ("isGrounded", m_isGrounded);
		HandleJump ();
		HandleDead ();
	}

	//ensure every computer have fair init speed and increate speed frequent
	void FixedUpdate () {
		AutoMove ();
		AutoIncreaseSpeed ();
	}

    private void OnCollisionEnter(Collision collision) {
        ContactPoint[] contactPoints = collision.contacts;
        for(int i = 0; i < contactPoints.Length; i++) {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f) {
                if (!m_collisions.Contains(collision.collider)) {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision) {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++) {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f) {
                validSurfaceNormal = true; break;
            }
        }
        if(validSurfaceNormal) {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider)) {
                m_collisions.Add(collision.collider);
            }
        } else {
            if (m_collisions.Contains(collision.collider)) {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { 
				m_isGrounded = false; 
			}
        }
    }

    private void OnCollisionExit(Collision collision) {
        if(m_collisions.Contains(collision.collider)) {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { 
			m_isGrounded = false; 
		}
    }

	private void AutoMove () {
		if (autoRun) {
			m_animator.SetFloat ("hSpeed", m_moveSpeed);
			m_rigidBody.velocity = new Vector3 (m_moveSpeed, m_rigidBody.velocity.y, 0f);
		}
	}

	private void AutoIncreaseSpeed() {
		if (autoIncreaseSpeed) {
			timeToIncreaseSpeedCounter -= Time.deltaTime;
			if (timeToIncreaseSpeedCounter < 0f) {
				m_moveSpeed++;
				timeToIncreaseSpeedCounter = timeToIncreaseSpeed;
			}
		}
	}

	//player can make a jump and double jump
	private void HandleJump () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (m_canDoubleJump && !m_isGrounded) {//double jump
				m_rigidBody.velocity = new Vector3 (m_rigidBody.velocity.x, 0f, m_rigidBody.velocity.z); 
				m_rigidBody.AddForce (new Vector3 (m_rigidBody.velocity.x, m_jumpForce, m_rigidBody.velocity.z));
				m_canDoubleJump = false;
			} else if (m_isGrounded) { //first jump
				m_rigidBody.velocity = new Vector3 (m_rigidBody.velocity.x, 0f, m_rigidBody.velocity.z); 
				m_rigidBody.AddForce (new Vector3 (m_rigidBody.velocity.x, m_jumpForce, m_rigidBody.velocity.z));
			} 
		}
		if (m_isGrounded) {//reset double jump when player is grounded
			m_canDoubleJump = true;
		}
		m_animator.SetFloat ("vSpeed", m_rigidBody.velocity.y);
	}
}
