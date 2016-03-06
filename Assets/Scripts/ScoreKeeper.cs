using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;

	private Text textDisplay;

	void Start () {
		ResetScore ();
		textDisplay = gameObject.GetComponent<Text> ();
		textDisplay.text = score.ToString ();
	}

	public void AddToScore (int points) {
		score += points;
		textDisplay.text = score.ToString ();
	}

	public static void ResetScore () {
		score = 0;
	}
}
