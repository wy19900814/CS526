using UnityEngine;
using System.Collections;

public class BombScript : PowerDownScript {
	int score = -100;


	public override void getEffects (GameControlScript gc){
		gc.addTime ((int)(-1 * gc.getTime()));
		gc.addScore (score);
	}
}
