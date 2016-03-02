using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float damage;

	public void OnHit ()
	{
		Destroy (gameObject);
	}
}
