using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingWithLocals : MonoBehaviour {
	GameObject localPerson;
	AudioClip clipToPlay;

	public void playAudioResponse(string nameOfLocal, string clip){
		localPerson = GameObject.Find (nameOfLocal);
		AudioSource audioSource = localPerson.GetComponentInChildren<AudioSource>();
		audioSource.clip = Resources.Load (clip) as AudioClip;
	}
}