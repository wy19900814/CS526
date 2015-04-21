using UnityEngine;
using System.Collections;

public class ClockScript : PowerupScript {
	int time = 5;

	public override void getEffects (GameControlScript gc){
		gc.addTime (time);
	}
}
