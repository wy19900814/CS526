using UnityEngine;
using System.Collections;

abstract public class ItemScript : MonoBehaviour {

	public float objectSpeed = -1.0f;
	
	void Update () {
		transform.Translate(0, 0, objectSpeed);
	}
	
	void Start(){
		#if UNITY_IOS
		objectSpeed = -1.0f;
		#endif
	}

	abstract public void getEffects(GameControlScript gc);
}
