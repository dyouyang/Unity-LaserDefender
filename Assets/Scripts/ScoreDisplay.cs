using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text P1ScoreText;
	public Text P2ScoreText;

	public Text winnerText;
	// Use this for initialization
	void Start () {

		int P1score = ScoreKeeper.scoreP1;
		int P2score = ScoreKeeper.scoreP2;

		P1ScoreText.text = P1score.ToString ();
		P2ScoreText.text = P2score.ToString ();

		if (P1score > P2score) {
			winnerText.text = "Player 1 Wins!";
		} else if (P2score > P1score) {
			winnerText.text = "Player 2 Wins!";
		} else {
			winnerText.text = "Equally matched!";
		}

		ScoreKeeper.ResetScore ();
	
	}

}
