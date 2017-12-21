using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour {
	float deathTime = 0;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (deathTime > 1.0f)
			Destroy (gameObject);
		else
			deathTime = deathTime + (1.0f * Time.deltaTime);
	}
}
