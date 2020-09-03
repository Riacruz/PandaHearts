using UnityEngine;
using System.Collections;

public class ComoJugar : MonoBehaviour {

	public GameObject thisObj;
	public GameObject nextObj;
	public bool boolFinalObj;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {	
		
		GetComponent<AudioSource> ().Play ();	
		Invoke ("DoIt", GetComponent<AudioSource> ().clip.length);

	}

	void DoIt() {
		if (boolFinalObj) {
			//GetComponent<AudioSource> ().Play ();			
			nextObj.SetActive (true);
		} else {

			nextObj.SetActive (true);
			thisObj.SetActive (false);
		}
	}
}
