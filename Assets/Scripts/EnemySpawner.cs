using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	public float width;
	public float height;
	public float baseMovementSpeed;
	float movementSpeed;
	public float spawnDelay;

	Vector3 movement;

	float xMin;
	float xMax;

	float difficultyModifier = 0f;

	// Use this for initialization
	void Start () {
	
		SpawnAllEnemies ();
		movementSpeed = baseMovementSpeed;
		movement = Vector3.right * Time.deltaTime * movementSpeed;
		setEdgeDetection ();
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));
	}


	// Update is called once per frame
	void Update () {
		transform.position += movement;

		// If the bounds are outside the edges, go in the correct direction
		if (transform.position.x + width / 2 >= xMax) {
			movement = Vector3.left * Time.deltaTime * movementSpeed;
		} else if (transform.position.x - width / 2 <= xMin) {
			movement = Vector3.right * Time.deltaTime * movementSpeed;
		}

		if (AllEnemiesAreDead ()) {
			difficultyModifier += 1.0f;
			SpeedUp();
			SpawnEnemiesUntilFull();
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

	bool AllEnemiesAreDead () {
		int enemiesLeft = transform.childCount;
		foreach (Transform position in transform) {
			if (position.childCount == 0) {
				enemiesLeft--;
			}
		}
		
		if (enemiesLeft == 0) {
			return true;
		} else {
			return false;
		}
	}

	Transform NextFreePosition() {
		foreach (Transform position in transform) {
			if (position.childCount == 0) {
				return position;
			}
		}

		// No free position in the formation.
		return null;
	}

	void SpawnAllEnemies() {
		// Get each "position" child in this spawner
		foreach (Transform childPosition in transform) {
			GameObject enemy = (GameObject) Instantiate (enemyPrefab, childPosition.transform.position, Quaternion.identity);
			enemy.transform.parent = childPosition;
		}
	}

	void SpawnEnemiesUntilFull() {
		Transform spawnAt = NextFreePosition ();
		if (spawnAt != null) {
			GameObject enemy = (GameObject) Instantiate (enemyPrefab, spawnAt.transform.position, Quaternion.identity);
			enemy.transform.parent = spawnAt;
			Invoke("SpawnEnemiesUntilFull", spawnDelay);
		}

	}

	void SpeedUp ()
	{
		movementSpeed = baseMovementSpeed + 1.0f * difficultyModifier;
	}
}
