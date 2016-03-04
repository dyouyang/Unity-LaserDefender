using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float hp;

	public GameObject laser;
	public float laserSpeed;

	public float shotsPerSecond = 0.5f;

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
			Destroy(gameObject);
		}
		projectile.OnHit ();
	}

	void FireZeMissile() {
		Vector3 laserPosition = transform.position + new Vector3 (0, -1, 0);
		laser = Instantiate (laser, laserPosition, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -laserSpeed);
	}
}
