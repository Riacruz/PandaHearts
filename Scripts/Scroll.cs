using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public bool iniciarEnMovimiento = false;
	public float velocidad = 0f;
	public Renderer render;
	private bool enMovimiento = false;
	private float tiempoInicio = 0f;
	public Material materialNegro;
	public Material materialPapelPintadoRosa;
    private bool cambio;
    private int puntos;

	// Use this for initialization
	void Start () {
        cambio = false;
        puntos = 0;
		NotificationCenter.DefaultCenter().AddObserver(this, "PeronajeEmpiezaAcorrer");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeHaMuerto");
		if (iniciarEnMovimiento) {
			enMovimiento = true;
		}
	}

	void PeronajeEmpiezaAcorrer () {
		enMovimiento = true;
		tiempoInicio = Time.time;
	}

	void PersonajeHaMuerto() {
		enMovimiento = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (enMovimiento) {
			render.material.mainTextureOffset = new Vector2 (((Time.time - tiempoInicio) * velocidad)%1, 0);
		}
        
		if (EstadoJuego.estadoJuego.puntosActuales - (puntos*100) >= 100) {
            if (!cambio) cambio = true; else cambio = false;
			GameObject.Find ("QuadDestello").GetComponent<Animator> ().SetBool ("destello", true);
            if (cambio)
            { //GetComponent<MeshRenderer>().sharedMaterial = materialNegro;
            }
            else
            {
                //GetComponent<MeshRenderer>().sharedMaterial = materialPapelPintadoRosa;
                cambio = false;
            }
            
            puntos += 1;

            Invoke ("DestelloFalso", 1f);
		}
        /*
		if (EstadoJuego.estadoJuego.puntosActuales > 30 && cambio2) {			
			//var text = materialPapelPintadoRosa.mainTexture;
			//text.wrapMode = TextureWrapMode.Clamp;
			GameObject.Find ("QuadDestello").GetComponent<Animator> ().SetBool ("destello", true);	
			GetComponent<MeshRenderer> ().sharedMaterial = materialPapelPintadoRosa;
			cambio2 = false;
			Invoke ("DestelloFalso", 1f);
		}
        */

	}

	void DestelloFalso() {
		GameObject.Find ("QuadDestello").GetComponent<Animator> ().SetBool ("destello", false);
	}
}
