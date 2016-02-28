using UnityEngine;
using System.Collections;

public class LaserShredder : MonoBehaviour {

	// Destroy laser objects to keep from flooding memory
	void OnTriggerEnter2D(Collider2D collider) {
		Destroy (collider.gameObject);
	}
}
