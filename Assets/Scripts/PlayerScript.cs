using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	Vector3 touchPosition;

	public GameObject [] obj;

	public Rigidbody2D rb;

	public SpriteRenderer sr1;

	public Color colorOrange;
	public Color colorYellow;
	public Color colorPurple;
	public Color colorGreen;

	float waitTime =1.0f;
	float currentTime = 0.0f;
	float swipeResistancex = 50.0f;
	float swipeResistancey = 100.0f;
	float force = 500.0f;

	bool right,left,up,down,gameOver = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr1 = GetComponent<SpriteRenderer> ();
		setRandomColor (sr1);
		for (int i = 0; i < obj.Length; i++)
			setRandomColor (obj[i].GetComponent<SpriteRenderer>());
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentMousePos = Input.mousePosition;
		left = right = up = down = false;
		if(Input.GetMouseButtonDown (0)){
			touchPosition = Input.mousePosition;
		}

		if (Input.GetMouseButtonUp (0)) {
			Vector2 deltaSwipe = currentMousePos - touchPosition;
			if (Mathf.Abs (deltaSwipe.x) > swipeResistancex) {
				if (deltaSwipe.x > 0) {
					right = true;
					left = up = down = false;
				}
				else if (deltaSwipe.x < 0) {
					left = true;
					right = up = down = false;
				}
			}
			if (Mathf.Abs (deltaSwipe.y) > swipeResistancey) {
				if (deltaSwipe.y > 0) {
					up = true;
					down = left = right = false;
				} else if (deltaSwipe.y < 0) {
					down = true;
					up = left = right = false;
				}
			}
		}

		currentTime += 1 * Time.deltaTime;

		if (currentTime > waitTime)
			DestroyShape ();

		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		if (inputX > 0 || right) {
			rb.AddForce (Vector2.right * force);
			inputX = 0;
			currentTime = 0;
		} else if (inputX < 0 || left) {
			rb.AddForce (Vector2.right * -1 * force);
			inputX = 0;
			currentTime = 0;
		}else if (inputY > 0 || up) {
			rb.AddForce (Vector2.up * force);
			inputY = 0;
			currentTime = 0;
		} else if (inputY < 0 || down) {
			rb.AddForce (Vector2.down * force);
			inputY = 0;
			currentTime = 0;
		}
	}
		public void DestroyShape(){
		//Instantiate (obj, transform.position, Quaternion.identity);
		Destroy (gameObject);
		}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Collision") {
			Debug.Log("Collision");
			if (other.GetComponent<SpriteRenderer> ().color == sr1.color) {
				SpawnPoint.score++;
			} else {
				gameOver = true;
			}
			DestroyShape ();
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
}
