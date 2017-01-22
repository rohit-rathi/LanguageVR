using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour {

	public void printMethod(){
		if (gameObject.name.Contains("Tour Guide")) {
			print ("Tour Guide");
		} else if (gameObject.name.Contains("Ticket Guy")) {
			Debug.Log ("Ticket guy");
		} else if (gameObject.name.Contains("Shop Guy")) {
			Debug.Log ("Shop Guy");
		}
	}
}
