using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzaSalto = 100f;
	public bool enSuelo = true;

	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.07f;
	public LayerMask mascaraSuelo;

	private bool dobleSalto = false;
	private Animator animator;
	private bool corriendo = false;
	public float velocidad = 10f;


	// Use this for initialization

	void Awake() {
		animator = GetComponent<Animator> ();

	}

	void Start () {
	
	}
	void FixedUpdate () {
		if (corriendo) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocidad, GetComponent<Rigidbody2D> ().velocity.y);

		}
		animator.SetFloat ("velX", GetComponent<Rigidbody2D> ().velocity.x);
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animator.SetBool ("isGrounded", enSuelo);

		if (enSuelo) {
			dobleSalto = false;
			Util.u.dobleSaltoCorazon = false;
			Util.u.intCombo = 0;
			Util.u.textCombo.GetComponent<TextMesh> ().text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Util.u.dobleSaltoCorazon) {
			dobleSalto = false;

		}
		if (Input.GetMouseButtonDown (0)) {
			if (corriendo) {
				if (enSuelo || !dobleSalto) {
					//GetComponent<Rigidbody2D> ().AddForce(new Vector2 (0, fuerzaSalto));
					GetComponent<AudioSource> ().Play();
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, fuerzaSalto);
					Util.u.dobleSaltoCorazon = false;
					if (!dobleSalto && !enSuelo) {
						dobleSalto = true;
					}
				}
			} else {
				corriendo = true;
				NotificationCenter.DefaultCenter ().PostNotification (this, "PeronajeEmpiezaAcorrer");
			}
		}

	
	}
}
