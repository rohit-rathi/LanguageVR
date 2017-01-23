using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingWithLocals : MonoBehaviour {
	GameObject localPerson;
	AudioClip clipToPlay;

	public void playAudioResponse(string nameClip){
		//localPerson = GameObject.Find (nameOfLocal);
		string[] nameClipArr = nameClip.Split('*');
		localPerson = GameObject.Find (nameClipArr [0]);
		AudioSource audioSource = localPerson.GetComponentInChildren<AudioSource>();
		audioSource.clip = Resources.Load (nameClipArr[1]) as AudioClip;
		//SpeechListener.OnStartRecordingPressed ();
	}
}