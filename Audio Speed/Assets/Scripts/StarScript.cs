using UnityEngine;
using System.Collections;

public class StarScript : PowerupScript {
	int score = 2;

	public AudioClip blurp;
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
		AudioSource.PlayClipAtPoint (blurp, transform.position);
	}

	void Update () {
		transform.Translate(0, objectSpeed, 0);
	}
}
