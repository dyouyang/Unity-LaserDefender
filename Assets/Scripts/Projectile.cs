using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float damage;

	public int playerNumber;

	public GameObject explosion;

	public void OnHit ()
	{
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
