﻿using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class BotonRanking : MonoBehaviour {

	private TextMesh textoBoton;
	private Color colorRosa;

	void Awake() {
		textoBoton = GetComponent<TextMesh>();
		colorRosa = GetComponent<TextMesh> ().color;
		ColorUtility.TryParseHtmlString ("#FF5DB1FF", out colorRosa);
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Social.localUser.authenticated) {			
			textoBoton.color = colorRosa;
			//textoBoton.color = Color.white;
		} else {
			textoBoton.color = Color.gray;
		}
	}

	void OnMouseDown() {
		
		if (Social.localUser.authenticated) {
			GetComponent<AudioSource> ().Play ();
			((PlayGamesPlatform)Social.Active).ShowLeaderboardUI ("CgkIuf7Ah8AfEAIQBg");
		} else {
			Social.localUser.Authenticate ((bool success) => {});
		}
	}
}
