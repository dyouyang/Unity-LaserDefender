using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
	
		// Get each "position" child in this spawner
		foreach (Transform childPosition in transform) {
			GameObject enemy = (GameObject) Instantiate (enemyPrefab, childPosition.transform.position, Quaternion.identity);
			enemy.transform.parent = childPosition;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
