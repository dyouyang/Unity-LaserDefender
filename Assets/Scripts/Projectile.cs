using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float damage;

	public int playerNumber;

	public void OnHit ()
	{
		Destroy (gameObject);
	}
}
