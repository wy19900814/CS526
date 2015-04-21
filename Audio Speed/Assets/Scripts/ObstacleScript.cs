using UnityEngine;
using System.Collections;

public class ObstacleScript : PowerDownScript {
	int score = -2;
	int time = -10;

	public override void getEffects (GameControlScript gc){
		gc.addScore (score);
		gc.addTime (time);
		if (!gc.cameraController.startRotate) {
			gc.cameraController.startRotate = true;
		}
	}

	void Start(){
		transform.localScale += new Vector3(0.12f, 0f, 0f);
	}
}