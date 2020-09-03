using UnityEngine;
using System.Collections;

public class DestroyThis : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (gameObject.activeSelf) {
			Invoke ("Destruye", 1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Destruye() {
		Destroy (gameObject);
	}
}
