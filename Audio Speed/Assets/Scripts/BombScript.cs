using UnityEngine;
using System.Collections;

public class BombScript : PowerDownScript {
	int score = -100;


	public override void getEffects (GameControlScript gc){
		gc.addTime ((int)(-1 * gc.getTime() - 1));
		gc.addScore (score);
	}

	void Update () {
		transform.Translate(-objectSpeed, 0, 0);
	}
}
