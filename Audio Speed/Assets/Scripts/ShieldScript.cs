using UnityEngine;
using System.Collections;

public class ShieldScript : PowerupScript {
	int score = 2;

	public override void getEffects (GameControlScript gc){
		gc.addScore (score);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, -objectSpeed, 0);
	}
}
