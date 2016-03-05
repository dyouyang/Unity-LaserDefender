using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public int score = 0;

	private Text textDisplay;

	void Start () {
		textDisplay = gameObject.GetComponent<Text> ();
		ResetScore ();
	}

	public void AddToScore (int points) {
		score += points;
		textDisplay.text = score.ToString ();
	}

	public void ResetScore () {
		score = 0;
		textDisplay.text = score.ToString ();
	}
}
