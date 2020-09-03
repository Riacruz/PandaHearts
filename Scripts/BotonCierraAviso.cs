using UnityEngine;
using System.Collections;

public class BotonCierraAviso : MonoBehaviour {
	public GameObject aviso;
	public GameObject[] botones;
	// Use this for initialization
	void Start () {
		if (aviso.activeSelf) {
			for (int i = 0; i <= botones.Length-1; i++) {
				botones [i].SetActive (false);
			}
		} 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		for (int i = 0; i <= botones.Length-1; i++) {
			botones [i].SetActive (true);
		}
		EstadoJuego.estadoJuego.GuardarAviso ();
		aviso.SetActive (false);
		Destroy (aviso);
	}
}
