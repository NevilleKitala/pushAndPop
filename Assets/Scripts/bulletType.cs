using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class bulletType : ScriptableObject {

	public float price = 10.0f;
	public Sprite spr;
	public Sprite borders;
	public bool unlocked = false;
}
