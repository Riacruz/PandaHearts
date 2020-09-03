using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

	public GameObject[] obj;
	public float tiempoMin = 1f;
	public float tiempoMax = 2f;
	private bool estaMuerto = false;
    public bool stopGenerar;
    public bool aviso;


	// Use this for initialization
	void Start () {
		//Generar ();
		NotificationCenter.DefaultCenter().AddObserver(this, "PeronajeEmpiezaAcorrer");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeHaMuerto");
	}

	void PeronajeEmpiezaAcorrer (Notification notificacion) {
		
		Generar ();

	}

	void PersonajeHaMuerto () {
		estaMuerto = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (aviso)
        {
            Generar();
            aviso = false;
        }
	}

	void Generar() {
		if (!estaMuerto && !stopGenerar) {
			Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
			Invoke ("Generar", Random.Range (tiempoMin, tiempoMax));
		}
	}
}
