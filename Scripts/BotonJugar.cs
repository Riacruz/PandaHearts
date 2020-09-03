using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotonJugar : MonoBehaviour {

	public string escena;

	// Use this for initialization
	void Start () {

        if (!PlayerPrefs.HasKey("vecesPulsado"))
        {
            PlayerPrefs.SetInt("vecesPulsado", 0);            
        } 

    }

    // Update is called once per frame
    void Update () {
		
	}

	void OnMouseDown() {
		Camera.main.GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().Play ();
		Invoke ("CargarNivel", GetComponent<AudioSource> ().clip.length);
        var vp = PlayerPrefs.GetInt("vecesPulsado");
        PlayerPrefs.SetInt("vecesPulsado", vp+1);

        //CargarNivel();

    }

	void CargarNivel() {
		//SceneManager.LoadSceneAsync (escena);
		SceneManager.LoadScene (escena);
	}
}
