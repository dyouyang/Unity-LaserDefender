using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int scoreP1 = 0;
	public static int scoreP2 = 0;

	public Text textDisplayP1;
	public Text textDisplayP2;

	void Start () {
		ResetScore ();
		textDisplayP1.text = scoreP1.ToString ();
		textDisplayP2.text = scoreP2.ToString ();
	}

	public void AddToScore (int points, int playerNumber) {

		if (playerNumber == 1) {
			scoreP1 += points;
			textDisplayP1.text = scoreP1.ToString ();
		} else if (playerNumber == 2) {
			scoreP2 += points;
			textDisplayP2.text = scoreP2.ToString ();
		}
	}

	public static void ResetScore () {
		scoreP1 = 0;
		scoreP2 = 0;
	}
}
