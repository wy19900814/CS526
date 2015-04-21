using UnityEngine;
using System.Collections;

abstract public class ItemScript : MonoBehaviour {

	public float objectSpeed = -0.5f;
	
	void Update () {
		transform.Translate(0, 0, objectSpeed);
	}
	
	void Start(){

	}

	abstract public void getEffects(GameControlScript gc);
}
