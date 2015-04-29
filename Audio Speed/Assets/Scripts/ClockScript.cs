using UnityEngine;
using System.Collections;

public class ClockScript : PowerupScript {
	int time = 10;

	public override void getEffects (GameControlScript gc){
		gc.addTime (time);
	}

	void Update () {
		transform.Translate(0, 0, -objectSpeed);
	}
}
