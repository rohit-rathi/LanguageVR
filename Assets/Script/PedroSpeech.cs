using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PedroSpeech : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip[] clips;
	public int currentClip = 0;

	public void Speak(){
		if (!audioSource.isPlaying) {
			if (currentClip < 3) {
				if (currentClip != 0) {
					Thread.Sleep (5000);
				}
				audioSource.clip = clips [currentClip];
				audioSource.Play ();
				Debug.Log ("HEY");
				currentClip++;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (currentClip > 0 && currentClip < 3) {
			Speak ();
		}
	}
}
