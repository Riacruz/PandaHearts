using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotonComoJugar : MonoBehaviour {

	public string escena;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Camera.main.GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().Play ();
		//Invoke ("CargarNivel", GetComponent<AudioSource> ().clip.length);
		CargarNivel();

	}

	void CargarNivel() {
		SceneManager.LoadScene (escena);
	}
}
