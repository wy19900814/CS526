using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {
	public float objectSpeed = -0.5f;

	public int score = 10;

	public int getScore(int s){
		return score;
	}


	void Update () {
		transform.Translate(0, 0, objectSpeed);
	}
}