using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMusic : MonoBehaviour {

	public GameObject musicPlayer;

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
	}
}