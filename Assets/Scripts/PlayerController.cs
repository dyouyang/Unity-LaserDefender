using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5.0f;

	float xMin;
	float xMax;

	public float padding = 1.0f;

	public GameObject laser;
	public float laserSpeed;

	public GameObject explosion;

	public float fireRate;

	public float hp;

	public AudioClip laserSound;
	public AudioClip deadSound;

	public int playerNumber;

	private Vector3 savedPosition;

	// Use this for initialization
	void Start () {

		// Set left and right edges for movement using camera viewport.
		float distanceObjectToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftSide = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distanceObjectToCamera));
		Vector3 rightSide = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,distanceObjectToCamera));
		xMin = leftSide.x + padding; 
		xMax = rightSide.x - padding;
	}
	
	// Update is called once per frame
	void Update () {

		if (playerNumber == 1) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.position += Vector3.left * speed * Time.deltaTime;  //deltaTime makes movement framerate agnostic.
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				transform.position += Vector3.right * speed * Time.deltaTime;
			}

			float clampedX = Mathf.Clamp (transform.position.x, xMin, xMax);
			transform.position = new Vector3 (clampedX, transform.position.y, transform.position.z);

			if (Input.GetKeyDown (KeyCode.Space)) {
				InvokeRepeating ("FireZeMissile", 0.000001f, fireRate);
			} else if (Input.GetKeyUp (KeyCode.Space)) {
				CancelInvoke ("FireZeMissile");
			}
		}

		if (playerNumber == 2) {
			if (Input.GetKey (KeyCode.A)) {
				transform.position += Vector3.left * speed * Time.deltaTime;  //deltaTime makes movement framerate agnostic.
			} else if (Input.GetKey (KeyCode.D)) {
				transform.position += Vector3.right * speed * Time.deltaTime;
			}
			
			float clampedX = Mathf.Clamp (transform.position.x, xMin, xMax);
			transform.position = new Vector3 (clampedX, transform.position.y, transform.position.z);
			
			if (Input.GetKeyDown (KeyCode.S)) {
				InvokeRepeating ("FireZeMissile", 0.000001f, fireRate);
			} else if (Input.GetKeyUp (KeyCode.S)) {
				CancelInvoke ("FireZeMissile");
			}
		}
	}

	void FireZeMissile() {

		if (playerNumber == 1) {
			Vector3 laserPosition = transform.position + new Vector3 (0, 1, 0);
			GameObject laserObject = Instantiate(laser, laserPosition, Quaternion.identity) as GameObject;
			laserObject.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, laserSpeed, 0);
			laserObject.GetComponent<Projectile> ().playerNumber = 1;


		} else if (playerNumber == 2) {
			Vector3 laserPosition = transform.position + new Vector3 (0, -1, 0);
			GameObject laserObject = Instantiate(laser, laserPosition, Quaternion.identity) as GameObject;
			laserObject.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -laserSpeed, 0);
			laserObject.GetComponent<Projectile> ().playerNumber = 2;


		}
		AudioSource.PlayClipAtPoint (laserSound, transform.position);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile projectile = collider.gameObject.GetComponent<Projectile> ();
		if (projectile != null) {
			TakeDamageFrom(projectile);
		}
	}
	
	void TakeDamageFrom (Projectile projectile)
	{
		// In 2P mode, only the other player's projectile really damages or destroys the player.
		if (projectile.playerNumber == 1 ||
			projectile.playerNumber == 2) {
			hp -= projectile.damage;
			if (hp <= 0) {
				DestroySelfAndGameOver ();
			}
		} else {

			// AI Enemy lasers merely temporarily disable the player for 2s
			savedPosition = transform.position;

			// Moves player ship out of the game space and disables any possible collisions
			transform.position += new Vector3 (0, 10000, 0);
			GetComponent<PolygonCollider2D> ().enabled = false;

			Invoke("Respawn", 2.0f);
		}
		projectile.OnHit ();
	}

	// After hit by AI enemy, respawn at original location
	void Respawn() {
		transform.position = savedPosition;
		GetComponent<PolygonCollider2D> ().enabled = true;
	}

	void DestroySelfAndGameOver() {
		AudioSource.PlayClipAtPoint (deadSound, transform.position);
		Destroy(gameObject);

		FindObjectOfType<LevelManager> ().LoadLevel ("Win Screen");
	}
}
