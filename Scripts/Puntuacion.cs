using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {


	public GameObject particleBlanco;
	public Transform particleBlancaPosicion;
	private int key = 0;
	private int _puntuacion = 0;
	private bool boolParticleBlanca;
	public int puntuacion {
		get { return _puntuacion ^ key; }
		set {
			key = Random.Range (0, int.MaxValue);
			_puntuacion = value ^ key;
		}
	}
	public TextMesh marcador;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "IncrementarPuntos");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeHaMuerto");
		ActualizarMarcador ();
		boolParticleBlanca = true;
	}

	void PersonajeHaMuerto(Notification notificacion) {
		if (puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima) {
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
			EstadoJuego.estadoJuego.Guardar ();
            
		}
        //Enviamos a Google Play la puntuacion obtenida

        Social.ReportScore (EstadoJuego.estadoJuego.puntuacionMaxima, "CgkIuf7Ah8AfEAIQBg", (bool success) => {});

		//Activamos las medallas

		if (puntuacion >= 50) {
			Social.ReportProgress("CgkIuf7Ah8AfEAIQAQ", 100.0,(bool success) => {});
		}
		if (puntuacion >= 100) {
			Social.ReportProgress("CgkIuf7Ah8AfEAIQAg", 100.0,(bool success) => {});
		}
		if (puntuacion >= 150) {
			Social.ReportProgress("CgkIuf7Ah8AfEAIQAw", 100.0,(bool success) => {});
		}
		if (puntuacion >= 200) {
			Social.ReportProgress("CgkIuf7Ah8AfEAIQBA", 100.0,(bool success) => {});
		}

		if (puntuacion >= 500) {
			Social.ReportProgress("CgkIuf7Ah8AfEAIQBQ", 100.0,(bool success) => {});
		}

		if (puntuacion >= 700) {
			Social.ReportProgress("CgkIuf7Ah8AfEAIQCA", 100.0,(bool success) => {});
		}

		if (puntuacion >= 1000) {
			Social.ReportProgress("CgkIuf7Ah8AfEAIQCQ", 100.0,(bool success) => {});
		}
	}

	void IncrementarPuntos (Notification notificacion) {
		int puntosIncrementados = (int)notificacion.data;
		if (Util.u.intCombo > 0) {
			puntosIncrementados = puntosIncrementados * Util.u.intCombo;
		}
		puntuacion += puntosIncrementados;
		if (puntuacion > 10 && boolParticleBlanca) {
		//	Instantiate (particleBlanco, new Vector3(particleBlancaPosicion.position.x,particleBlanco.transform.position.y,particleBlanco.transform.position.z),  particleBlanco.transform.rotation);
			boolParticleBlanca = false;
		}
		ActualizarMarcador ();
	}

	void ActualizarMarcador() {
		marcador.text = puntuacion.ToString ();
		EstadoJuego.estadoJuego.puntosActuales = puntuacion;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
