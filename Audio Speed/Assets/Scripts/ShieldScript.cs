using UnityEngine;
using System.Collections;

public class ShieldScript : PowerupScript {
	int score = 2;

	public override void getEffects (GameControlScript gc){
		gc.addScore (score);
		gc.playerController.invincible = true;
		startInvincibleEffect (gc.playerController);
	}

	void startInvincibleEffect(PlayerControl pc){
		//pc.animation.Play ("jump_pose");
		var particle = pc.character.GetComponent<ParticleSystem> ();
		particle.Play();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, -objectSpeed, 0);
	}
}
