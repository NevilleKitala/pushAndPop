﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class deathMenu : MonoBehaviour {
	public Text text;
	public Text highscore;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}

	public void setActiveMenu(){
		gameObject.SetActive (true);
	}
	public void StartMenu(){
		SceneManager.LoadScene ("GameMenu");
	}

	public void restart() {
		SceneManager.LoadScene ("Game");
	}

	public void DisplayScore(float score){
		text.text = score.ToString();
	}
	public void highScore(float score){
		highscore.text = score.ToString ();
		PlayerPrefs.SetFloat ("Highscore", score);
	}
}
