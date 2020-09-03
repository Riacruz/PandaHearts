using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {
    GameObject panda;
	// Use this for initialization
	void Start () {
        panda = GameObject.Find("Panda");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player" || collider.tag == "PlayerPatas") {
			//Debug.Break ();
			NotificationCenter.DefaultCenter ().PostNotification (this, "PersonajeHaMuerto");
			
			panda.SetActive (false);
		} else {
            if(collider.tag != "Star") Destroy (collider.gameObject);
		}
	}
}
