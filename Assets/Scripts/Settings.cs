using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Settings : MonoBehaviour {

	AudioSource audiosr;
	GameObject source;

	public Slider volume;
	public Slider effects;

	// Use this for initialization
	void Start () {
		source = GameObject.Find ("MainCamera");
		gameObject.SetActive(false);
		audiosr = source.GetComponent<AudioSource> ();
	}

	void Update() {
		volume.value = PlayerPrefs.GetFloat ("Volume");
		effects.value = PlayerPrefs.GetFloat ("Effects");
	}
	public void setActiveSettings (){
		gameObject.SetActive (true);
	}

	public void setInactiveSettings () {
		gameObject.SetActive (false);
	}
	public void setVolume (float volume){
		PlayerPrefs.SetFloat ("Volume", volume);
		audiosr.volume = volume;
	}

	public void setEffects (float volume) {
		PlayerPrefs.SetFloat ("Effects", volume);
	}
}
