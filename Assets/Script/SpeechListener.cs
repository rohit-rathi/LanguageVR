using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using KKSpeech;
using System.Globalization;

public class SpeechListener : MonoBehaviour {

	public GameObject person;
	public string languageOption = "es-ES";
	//public Text resultText; 

	//Initialize Dicationaries
	public Dictionary<string, Dictionary<string, string>> conversations = new Dictionary<string, Dictionary<string, string>>();


	//Local Convo 1

	//Local Convo 2

	//Local Convo 3

	//Shop Guy

	//Ticket Guy 


	void Start() {
//		conversations.Add("Tour Guide", new Dictionary<string, string>());
//		conversations.Add("Tour Guide(Clone)", new Dictionary<string, string>());
//		conversations.Add("Tour Guide(Clone)(Clone)", new Dictionary<string, string>());
//		conversations.Add("Shop Guy", new Dictionary<string, string>());
//		conversations.Add("Ticket Guy", new Dictionary<string, string>());
		if (SpeechRecognizer.ExistsOnDevice()) {
			SpeechRecognizerListener listener = GameObject.FindObjectOfType<SpeechRecognizerListener>();
			listener.onAuthorizationStatusFetched.AddListener(OnAuthorizationStatusFetched);
			listener.onAvailabilityChanged.AddListener(OnAvailabilityChange);
			listener.onErrorDuringRecording.AddListener(OnError);
			listener.onErrorOnStartRecording.AddListener(OnError);
			listener.onFinalResults.AddListener(OnFinalResult);
			listener.onEndOfSpeech.AddListener(OnEndOfSpeech);
//			startRecordingButton.enabled = false;
			SpeechRecognizer.RequestAccess();
			SpeechRecognizer.SetDetectionLanguage(languageOption);
		} else {
			Debug.Log("Sorry, but this device doesn't support speech recognition");
//			startRecordingButton.enabled = false;
		}

	}

	public void OnFinalResult(string result) {
		string s = "quiero comprar dos pasajes";
		string resultWithoutAccent = RemoveDiacritics(result.ToLower());
		int match = LevenshteinDistance.Compute(resultWithoutAccent, s);
		List<string> incorrectWords = new List<string>();
		//resultText.text = result + " " + match;
		if (match > 0) {
			foreach (string word in resultWithoutAccent.Split(' ')) {
				int index = s.IndexOf(word);
				if (index == -1) { incorrectWords.Add(word); }
			}
			/*foreach (string word in incorrectWords) {
				resultText.text = resultText.text + " " + word;
			}*/
		}
		//Debug.Log (resultText.text);
	}

	static string RemoveDiacritics(string text) 
	{
		var normalizedString = text.Normalize(NormalizationForm.FormD);
		var stringBuilder = new StringBuilder();

		foreach (var c in normalizedString)
		{
			var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
			if (unicodeCategory != UnicodeCategory.NonSpacingMark)
			{
				stringBuilder.Append(c);
			}
		}

		return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
	}


	public void OnAvailabilityChange(bool available) {
//		startRecordingButton.enabled = available;
		if (!available) {
//			resultText.text = Debug.Log("Speech Recognition not available");
			Debug.Log("Speech Recognition not available");
		} else {
//			resultText.text = Debug.Log("Say something :-)");
			Debug.Log("Say something :-)");
		}
	}


	public void OnAuthorizationStatusFetched(AuthorizationStatus status) {
		switch (status) {
		case AuthorizationStatus.Authorized:
//			startRecordingButton.enabled = true;
			break;
		default:
//			startRecordingButton.enabled = false;
			//resultText.text = "Cannot use Speech Recognition, authorization status is " + status;
			//Debug.Log (resultText.text);
			break;
		}
	}

	public void OnEndOfSpeech() {
//		startRecordingButton.GetComponentInChildren<Text>().text = "Start Recording";
	}

	public void OnError(string error) {
		Debug.LogError(error);
		//resultText.text = "Something went wrong... Try again! \n [" + error + "]";
//		startRecordingButton.GetComponentInChildren<Text>().text = "Start Recording";
	}

	public void OnStartRecordingPressed() {
		if (SpeechRecognizer.IsRecording()) {
			SpeechRecognizer.StopIfRecording();
//			startRecordingButton.GetComponentInChildren<Text>().text = "Start Recording" + " " + languageOption;
			Debug.Log("Start Recording" + " " + languageOption);
		} else {
			SpeechRecognizer.StartRecording(true);
//			startRecordingButton.GetComponentInChildren<Text>().text = "Stop Recording" + " " + languageOption;
			Debug.Log("Start Recording" + " " + languageOption);
		}
	}
}
