using UnityEngine;
using System.Collections;

public class StarScript : PowerupScript {
	int score = 2;


	public override void getEffects (GameControlScript gc){
		gc.addScore (score);
	}

	void Update () {
		transform.Translate(0, objectSpeed, 0);
	}
}
