using UnityEngine;
using System.Collections;

public class ActivarGameOver : MonoBehaviour {

	public GameObject cameraGameOver;
    public VideoAdsMob ads;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeHaMuerto");
	}

	void PersonajeHaMuerto() {
		cameraGameOver.SetActive (true);
		Camera.main.GetComponent<AudioSource> ().Stop ();
        if(ads.verVideo)
        {
            //Invoke("LoadAds", 1);
            LoadAds();

        }
	}
	void LoadAds()
    {
        PlayerPrefs.SetInt("vecesPulsado", 0);
        ads.GameOver();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
