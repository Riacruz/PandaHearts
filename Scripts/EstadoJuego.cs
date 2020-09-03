using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class EstadoJuego : MonoBehaviour {

	public static EstadoJuego estadoJuego;

	public int puntuacionMaxima = 0;
	private string rutaArchivo;
	public string rutaArchivoAvisoLeido;
	public int puntosActuales;




	void Awake() {		
		rutaArchivo = Application.persistentDataPath + "/datos.dat";
		rutaArchivoAvisoLeido = Application.persistentDataPath + "/leido.dat";
	//	Debug.Log (rutaArchivoAvisoLeido);
		if (estadoJuego == null) {
			estadoJuego = this;
			DontDestroyOnLoad (gameObject);
			PlayGamesPlatform.Activate ();
			PlayGamesPlatform.DebugLogEnabled = false; //OJO desactivar al finalizar

		} else if (estadoJuego != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Cargar ();
		((PlayGamesPlatform)Social.Active).Authenticate ((bool success) => {}, true);


	}
	
	// Update is called once per frame
	void Update () {
        //print(SceneManager.GetActiveScene().name);
	}

	void Cargar() {
		if (File.Exists (rutaArchivo)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (rutaArchivo, FileMode.Open);
			DatosAGuardar datos = (DatosAGuardar)bf.Deserialize (file);
			puntuacionMaxima = datos.puntuacionMaxima;
			file.Close ();
		} else {
			puntuacionMaxima = 0;
		}
	}

	public void Guardar() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (rutaArchivo);
		DatosAGuardar datos = new DatosAGuardar ();
		datos.puntuacionMaxima = puntuacionMaxima;
		bf.Serialize (file, datos);
		file.Close ();
	}

	public void GuardarAviso() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (rutaArchivoAvisoLeido);
		DatosAGuardar datos = new DatosAGuardar ();
		datos.avisoLeido = "Leido";
		bf.Serialize (file, datos);
		file.Close ();

	}
}

[Serializable]
class DatosAGuardar {
	public int puntuacionMaxima;
	public string avisoLeido;
}
