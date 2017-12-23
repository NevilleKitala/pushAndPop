using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMusic : MonoBehaviour {

	public GameObject musicPlayer;

	public AudioSource audiosr;

	void Start(){
		audiosr = gameObject.GetComponent<AudioSource> ();
	}
		
	void Awake() {
		
		musicPlayer = GameObject.Find("MainCamera");

		if(musicPlayer==null)
		{
			
			musicPlayer = this.gameObject;
			musicPlayer.name = "MainCamera";
			DontDestroyOnLoad(musicPlayer);

		}else{
			if(this.gameObject.name!="MainCamera"){
				
				Destroy(this.gameObject);
			}
		}

		if (PlayerPrefs.GetFloat ("Volume") > 0)
			audiosr.volume = PlayerPrefs.GetFloat ("Volume");
		else
			audiosr.volume = 1.0f;
	}
}