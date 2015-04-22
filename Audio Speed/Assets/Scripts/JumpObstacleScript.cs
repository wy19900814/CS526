using UnityEngine;
using System.Collections;

public class JumpObstacleScript : PowerDownScript {
	int score = -2;
	int time = -10;

	public override void getEffects (GameControlScript gc){
		gc.addScore (score);
		gc.addTime (time);
		if (!gc.cameraController.startRotate && (challengeScript.rotationflag > 0)) {
			gc.cameraController.startRotate = true;
		}
	}

	void Update () {
		transform.Translate(-objectSpeed, 0, 0);
	}
}