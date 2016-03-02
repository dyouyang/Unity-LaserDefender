using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float hp;


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
}
