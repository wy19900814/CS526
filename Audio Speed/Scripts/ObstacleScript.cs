using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {
	public float objectSpeed = -0.5f;
	
	void Update () {
		transform.Translate(0, objectSpeed, 0);
	}

	void Start(){
		transform.localScale += new Vector3(0.12f, 0f, 0f);
	}
}