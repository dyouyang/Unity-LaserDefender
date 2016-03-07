using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	public AudioClip startMenuMusic;
	public AudioClip gameMusic;
	public AudioClip endMusic;

	private AudioSource audioSource;
	
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);

			audioSource = GetComponent<AudioSource>();
			audioSource.loop = true;
			audioSource.clip = startMenuMusic;
			audioSource.Play();

		}
		
	}

	void OnLevelWasLoaded(int level) {
		Debug.Log ("Loaded level");

		if (level == 0) {
			// Start Menu
			audioSource.clip = startMenuMusic;
		} else if (level == 1) {
			// Game
			audioSource.clip = gameMusic;
		} else if (level == 2) {
			audioSource.clip = endMusic;
		}
		audioSource.Play ();
	}
}
