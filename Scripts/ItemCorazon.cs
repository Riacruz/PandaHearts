using UnityEngine;
using System.Collections;

public class ItemCorazon : MonoBehaviour {

	public int puntosGanados = 5;
	public AudioClip itemSoundClip;
	public AudioClip soundYeah;
	public float itemSoundVolume = 1f;
	public GameObject particle;
    private Generador generador;
    public bool isItemStar;
    private CircleCollider2D coll;
    private SpriteRenderer rend;
    private ControladorPersonaje player;
    private AudioSource music;
    private ParticleSystem  particleStar, particleStar2;
    public int tiempoEstrella = 10;


    // Use this for initialization
    void Start () {
        generador = GameObject.FindGameObjectWithTag("SueloContinuo").GetComponent<Generador>();
        particleStar2 = GameObject.Find("ParticleStar2").GetComponent<ParticleSystem>();
        player = GameObject.Find("Panda").GetComponent<ControladorPersonaje>();       
        music = GameObject.Find("MainCamera").GetComponent<AudioSource>();
        GameObject go = GameObject.FindGameObjectWithTag("ParticleStar");
        particleStar = go.GetComponent<ParticleSystem>();        
        rend = GetComponent<SpriteRenderer>();
        coll = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void StopBloqueContinuo()
    {
        generador.stopGenerar = true;
        print("Stop generador bloue continuo");
        particleStar.Stop();
        particleStar2.Stop();
        player.velocidad = 8;
        music.pitch = 1f;
        Destroy(gameObject);
        
    }

    private void InvBloqueContinuo()
    {
        particleStar.Play();
        particleStar2.Play();
        Invoke("StopBloqueContinuo", tiempoEstrella);
        rend.enabled = false;
        coll.enabled = false;
        player.velocidad = 13;
        music.pitch = 1.1f;
        
    }
	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {	

			Instantiate (particle, transform.position, Quaternion.identity);
            
			Util.u.dobleSaltoCorazon = true;
			Util.u.intCombo++;
			if (Util.u.intCombo > 1) {
                Util.u.textCombo.GetComponent<TextMesh> ().text = "x" + Util.u.intCombo;
                Util.u.textCombo.transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
                //Instantiate(particle, new Vector3(Util.u.textCombo.transform.position.x+5, Util.u.textCombo.transform.position.y, Util.u.textCombo.transform.position.z), Quaternion.identity);
                AudioSource.PlayClipAtPoint (soundYeah, Camera.main.transform.position, 1f);
			}

			NotificationCenter.DefaultCenter ().PostNotification (this, "IncrementarPuntos", puntosGanados);
			AudioSource.PlayClipAtPoint (itemSoundClip, Camera.main.transform.position, itemSoundVolume);
            if(isItemStar)
            {
                generador.aviso = true;
                generador.stopGenerar = false;                
                InvBloqueContinuo();
                
            } else
            {
                Destroy(gameObject);
            }
			
		}
	}
}
