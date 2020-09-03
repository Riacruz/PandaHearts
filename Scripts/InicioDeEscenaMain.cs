using UnityEngine;
using System.Collections;
using System.IO;

public class InicioDeEscenaMain : MonoBehaviour {
	public GameObject[] botones;
	public GameObject objAviso;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("vecesPulsado", 0);
        if (objAviso != null) {
			if (File.Exists (EstadoJuego.estadoJuego.rutaArchivoAvisoLeido)) {	
				//Debug.Log ("HOLA");
				for (int i = 0; i <= botones.Length - 1; i++) {
					botones [i].SetActive (true);
				}
				objAviso.SetActive (false);
				Destroy (objAviso);

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
