using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Text textDisplay = GetComponent<Text> ();
		textDisplay.text = ScoreKeeper.score.ToString ();
		ScoreKeeper.ResetScore ();
	
	}

}
