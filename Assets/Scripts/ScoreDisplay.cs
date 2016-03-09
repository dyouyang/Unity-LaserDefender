using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text P1ScoreText;
	public Text P2ScoreText;

	// Use this for initialization
	void Start () {

		P1ScoreText.text = ScoreKeeper.scoreP1.ToString ();
		P2ScoreText.text = ScoreKeeper.scoreP2.ToString ();

		ScoreKeeper.ResetScore ();
	
	}

}
