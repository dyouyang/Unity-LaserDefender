using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5.0f;

	float xMin;
	float xMax;

	public float padding = 1.0f;

	// Use this for initialization
	void Start () {

		// Set left and right edges for movement using camera viewport.
		float distanceObjectToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftSide = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distanceObjectToCamera));
		Vector3 rightSide = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,distanceObjectToCamera));
		xMin = leftSide.x + padding; 
		xMax = rightSide.x - padding;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;  //deltaTime makes movement framerate agnostic.
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		float clampedX = Mathf.Clamp (transform.position.x, xMin, xMax);
		transform.position = new Vector3 (clampedX, transform.position.y, transform.position.z);
	}
}
