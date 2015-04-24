using UnityEngine;
using System.Collections;

public class PillarObstacleScript : PowerDownScript {
	int score = -2;
	int time = -10;

	public override void getEffects (GameControlScript gc){
		if (challengeScript.bombflag > 0) {
			score = score * 2;
		}
		if (challengeScript.rotationflag > 0) {
			score = score * 3;
		}
		if (challengeScript.timeflag > 0) {
			score = score * 5;
		}

		gc.addScore (score);
		gc.addTime (time);
		if (!gc.cameraController.startRotate && (challengeScript.rotationflag > 0)) {
			gc.cameraController.startRotate = true;
		}
	}

	void Update () {
		transform.Translate(0, 0, objectSpeed);
	}
}