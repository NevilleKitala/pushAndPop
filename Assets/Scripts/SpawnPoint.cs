using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPoint : MonoBehaviour {
	public GameObject sprite;

	GameObject obj = null;

	public SpriteRenderer [] borders;
	public Text text;

	public float currentPoints;
	public float score = 0.0f;
	public static float levelUp = 10.0f;

	public bool firstTouch,over = false;

	public Color colorOrange;
	public Color colorYellow;
	public Color colorPurple;
	public Color colorGreen;

	public deathMenu death;

	// Use this for initialization
	void Start () {
		score = 0.0f;
		levelUp = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (obj != null && obj.GetComponent<PlayerScript> ().gameOver == true)
			over = true;
		
		if (obj != null && !firstTouch && score == 0.0f)
			obj.GetComponent<PlayerScript> ().currentTime = 0.0f;
		else if (!firstTouch && score > 0.0f)
			firstTouch = true;

		if (firstTouch && score < 1.0f && !over) {
			death.setActiveMenu ();
			death.DisplayScore (score);
			AddUp (score);
			death.highScore (checkHighscore(score));
			over = true;
		}

		if (over == true) {
			death.setActiveMenu ();
			death.DisplayScore (score);
			AddUp (score);
			death.highScore (checkHighscore(score));
		}else if(!over){
			Spawn ();
			Score (text);
		}

		if (score > levelUp) 
			levelUp = levelUp * 2;

		Debug.Log (levelUp * 0.1);
	}

	void Spawn(){
		if (obj == null) {
			obj = Instantiate (sprite, transform.position, Quaternion.identity)as GameObject;
			assignColor (borders);
			setTextColor (text);
		} 

	}

	void Score (Text text){
		text.text = score.ToString();
	}

	void assignColor(SpriteRenderer [] arr){
		
		for (int i = 0; i < arr.Length ; i++){
			if(i < 1)
				setRandomColor(arr[i].GetComponent<SpriteRenderer>());
			else if (i < 2) {
				while (arr [i].GetComponent<SpriteRenderer> ().color == arr [i - 1].GetComponent<SpriteRenderer> ().color ||  arr [i].GetComponent<SpriteRenderer> ().color == Color.white) {
					setRandomColor (arr [i].GetComponent<SpriteRenderer> ());
				}
			} else if (i < 3) {
				while (arr [i].GetComponent<SpriteRenderer> ().color == arr [i - 1].GetComponent<SpriteRenderer> ().color || arr [i].GetComponent<SpriteRenderer> ().color == arr [i - 2].GetComponent<SpriteRenderer> ().color ||  arr [i].GetComponent<SpriteRenderer> ().color == Color.white) {
					setRandomColor (arr [i].GetComponent<SpriteRenderer> ());
				}
			} else if (i < 4) {
				while (arr [i].GetComponent<SpriteRenderer> ().color == arr [i - 1].GetComponent<SpriteRenderer> ().color || arr [i].GetComponent<SpriteRenderer> ().color == arr [i - 2].GetComponent<SpriteRenderer> ().color || arr [i].GetComponent<SpriteRenderer> ().color == arr [i - 3].GetComponent<SpriteRenderer> ().color || arr [i].GetComponent<SpriteRenderer> ().color == Color.white) {
					setRandomColor (arr [i].GetComponent<SpriteRenderer> ());
				}
			}
		}
	}

	void setRandomColor (SpriteRenderer sr){

		int index = Random.Range (0, 4);

		switch (index) {
		case 0:
			sr.color = colorOrange;
			break;
		case 1:
			sr.color = colorYellow;
			break;
		case 2:
			sr.color = colorPurple;
			break;
		case 3:
			sr.color = colorGreen;
			break;
		}
}

	void setTextColor (Text sr){
		
		int index = Random.Range (0, 4);

		switch (index) {
		case 0:
			sr.color = colorOrange;
			break;
		case 1:
			sr.color = colorYellow;
			break;
		case 2:
			sr.color = colorPurple;
			break;
		case 3:
			sr.color = colorGreen;
			break;
		}
	}

	float checkHighscore (float score){
		float highscore = PlayerPrefs.GetFloat ("Highscore");

		if (highscore < score) {
			PlayerPrefs.SetFloat ("Highscore", score);
			highscore = score;
		}
		return highscore;
	}

	void AddUp (float score){
		currentPoints = PlayerPrefs.GetFloat ("Points");
		currentPoints = currentPoints + score;
		PlayerPrefs.SetFloat ("Points", currentPoints);
	}
}