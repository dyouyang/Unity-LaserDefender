using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	public float width;
	public float height;
	public float movementSpeed;

	Vector3 movement;

	float xMin;
	float xMax;

	// Use this for initialization
	void Start () {
	
		// Get each "position" child in this spawner
		foreach (Transform childPosition in transform) {
			GameObject enemy = (GameObject) Instantiate (enemyPrefab, childPosition.transform.position, Quaternion.identity);
			enemy.transform.parent = childPosition;
		}

		movement = Vector3.right * Time.deltaTime * movementSpeed;
		setEdgeDetection ();
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));
	}


	// Update is called once per frame
	void Update () {
		transform.position += movement;

		// If the bounds are outside the edges, reverse direction
		if (transform.position.x + width / 2 >= xMax
			|| transform.position.x - width / 2 <= xMin) {

			movement *= -1;
		}

	}

	void setEdgeDetection ()
	{
		// Set left and right edges for movement using camera viewport.
		float distanceObjectToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftSide = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distanceObjectToCamera));
		Vector3 rightSide = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,distanceObjectToCamera));
		xMin = leftSide.x; 
		xMax = rightSide.x;
	}
}
