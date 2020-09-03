using UnityEngine;
using System.Collections;

public class Traductor : MonoBehaviour {
	public static Traductor traductor;

	public GameObject botonJugar;
	public GameObject botonRanking;
	public GameObject botonMedallas;
	public GameObject botonComoJugar;
	public GameObject botonSalir;

	public GameObject novedades;
	public GameObject descripcion;
	public GameObject descripcion1;
	public GameObject descripcion2;



	public GameObject punto1;
	public GameObject punto2;
	public GameObject punto3;
	public GameObject punto4;
	public GameObject punto41;
	public GameObject punto5;
	public GameObject punto51;
	public GameObject punto52;
	public GameObject botonVolver;

	// Use this for initialization
	void Start () {
		/* if (traductor == null) {
			traductor = this;
			DontDestroyOnLoad (gameObject);

		} else if (traductor != this) {
			Destroy (gameObject);
		}

*/
	}


	void FixedUpdate() {
		if (!Application.systemLanguage.ToString ().Equals ("Spanish")) {
			if (novedades != null) {
				novedades.GetComponent<TextMesh> ().text = "What's New v1.3";
			}
			if (descripcion != null) {
				descripcion.GetComponent<TextMesh> ().text = "- Hearts's combos";
			}
			if (descripcion1 != null) {
				descripcion1.GetComponent<TextMesh> ().text = "- Get your own Medal!!";
			}
			if (descripcion2 != null) {
				descripcion2.GetComponent<TextMesh> ().text = "See section HOW TO PLAY \n for more information";
			}



			if (botonJugar != null) {
				botonJugar.GetComponent<TextMesh> ().text = "PLAY";
			}
			if (botonRanking != null) {
				botonRanking.GetComponent<TextMesh> ().text = "RANKING";
			}
			if (botonMedallas != null) {
				botonMedallas.GetComponent<TextMesh> ().text = "MEDALS";
			}
			if (botonComoJugar != null) {
				botonComoJugar.GetComponent<TextMesh> ().text = "HOW TO PLAY";
			}
			if (botonSalir != null) {
				botonSalir.GetComponent<TextMesh> ().text = "EXIT";
			}
			if (botonVolver != null) {
				botonVolver.GetComponent<TextMesh> ().text = "BACK";
			}
			if (punto1 != null) {
				punto1.GetComponent<TextMesh> ().text = "To begin , press the screen \n and start running Panda";
			}
			if (punto2 != null) {
				punto2.GetComponent<TextMesh> ().text = "Touch the screen once to jump,\ntwice for double jump";
			}
			if (punto3 != null) {
				punto3.GetComponent<TextMesh> ().text = "Take a heart \n gives you an extra jump";
			}
			if (punto4 != null) {
				punto4.GetComponent<TextMesh> ().text = "Stepping on a platform = 1 point\nTake a heart = 5 points";
			}

			if (punto41 != null) {
				punto41.GetComponent<TextMesh> ().text = "Multiplies x2 , x3 , x4 ... score\nThe more you catch heart\nwithout touching the ground";
			}

			if (punto5 != null) {
				punto5.GetComponent<TextMesh> ().text = "News v1.4";
			}
			if (punto51 != null) {
				punto51.GetComponent<TextMesh> ().text = "- More hearts!/n" +
                    "- Night and day/n" +
                    "- Recoge la estrella y hazte inmortal por un tiempo/n"+
                    "- Medals up to 1200 points";
			}
			if (punto52 != null) {
				punto52.GetComponent<TextMesh> ().text = "GOOD LUCK!!";
			}

		}

	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
