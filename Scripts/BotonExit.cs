using UnityEngine;
using System.Collections;

public class BotonExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		GetComponent<AudioSource> ().Play ();
		Debug.Log ("Exit");
		Application.Quit ();
	}
}
