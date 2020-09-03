using UnityEngine;
using System.Collections;

public class TocaBloques : MonoBehaviour {

	private bool haColisionadoConPlayer = false;
	public int puntosGanados = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (!haColisionadoConPlayer && (collision.collider.gameObject.name == "Pata L" || 
			collision.collider.gameObject.name == "Pata R")) {
			haColisionadoConPlayer = true;


			NotificationCenter.DefaultCenter ().PostNotification (this, "IncrementarPuntos", puntosGanados);
		}

	}
}
