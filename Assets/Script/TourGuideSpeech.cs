using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TourGuideSpeech : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip[] clips;
	public int currentClip;
	public int lastClip;

	void Start(){
		if (gameObject.name == "Tour Guide") {
			currentClip = 0;
			lastClip = 5;
		} else if (gameObject.name == "Tour Guide(Clone)") {
			//currentClip = 6;
			lastClip = 7;
		} else if (gameObject.name == "Tour Guide(Clone)(Clone)") {
			//currentClip = 7;
			lastClip = 8;
		}
	}

	public void Speak(){
		if (!audioSource.isPlaying) {
			if (currentClip > 0 && currentClip != 4 && currentClip < lastClip) {
				Thread.Sleep (3000);
			} else if (currentClip == 4) {
				Thread.Sleep(5000);
			}
			if (currentClip < lastClip) {
				audioSource.clip = clips [currentClip];
				audioSource.Play ();
				Debug.Log ("HEY");
				currentClip++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentClip < lastClip) {
			Speak ();
		}
	}
}
