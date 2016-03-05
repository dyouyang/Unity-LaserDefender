using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float hp;

	public GameObject laser;
	public float laserSpeed;

	public float shotsPerSecond = 0.5f;

	int scoreWorth = 150;

	public ScoreKeeper scoreKeeper;

	public AudioClip destroyedSound;
	public AudioClip laserSound;

	void Start() {
		scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper> ();
	}

	void Update () {
		float probabilityToFire = shotsPerSecond * Time.deltaTime;

		// Effectively fire with a probability, since random value is between 0 and 1
		if (Random.value < probabilityToFire) {
			FireZeMissile ();
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Projectile projectile = collider.gameObject.GetComponent<Projectile> ();
		if (projectile != null) {
			TakeDamageFrom(projectile);
		}
	}

	void TakeDamageFrom (Projectile projectile)
	{
		hp -= projectile.damage;
		if (hp <= 0) {
			scoreKeeper.AddToScore(this.scoreWorth);
			print ("destroyed adding " + scoreWorth.ToString());
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(destroyedSound, transform.position);
		}
		projectile.OnHit ();
	}

	void FireZeMissile() {
		laser = Instantiate (laser, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -laserSpeed);
		AudioSource.PlayClipAtPoint (laserSound, transform.position, 0.25f);
	}
}
