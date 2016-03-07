using UnityEngine;
using System.Collections;

public class MultiplayerManager : MonoBehaviour {


	// Num players is set depending on which start menu button was clicked.
	// Destroy player 2 ship if only 1P mode is selected.
	public static int numPlayers = 1;

	public void setNumPlayers(int players) {
		numPlayers = players;
	}

	void Start () {
		if (numPlayers == 1) {
			Destroy (GameObject.Find("player2Ship"));
		}
	}
}
