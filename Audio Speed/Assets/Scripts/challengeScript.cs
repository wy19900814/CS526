using UnityEngine;
using System.Collections;

public class challengeScript : MonoBehaviour {
    public Renderer rend;

	public int mode = 0;
	public GameObject bomb;
	public GameObject time;
	public GameObject rotation;
	public GameObject done;

	public static int bombflag = 0;
	public static int rotationflag = 0;
	public static int timeflag = 0;

	static float timeLimit = 0; 
	float moveSpeed = 0.15f;

    void Start() {
        rend = GetComponent<Renderer>();
		bomb = GameObject.Find("txt_bomb");
		time = GameObject.Find("txt_time");
		rotation = GameObject.Find("txt_rotation");
		done = GameObject.Find("txt_done");

		if(bombflag == 0)
			bomb.renderer.material.color = Color.grey;
		else {
			bomb.renderer.material.color = Color.red;
		}
		if(timeflag == 0)
			time.renderer.material.color = Color.grey;
		else {
			time.renderer.material.color = Color.red;
		}
		if(rotationflag == 0)
			rotation.renderer.material.color = Color.grey;
		else {
			rotation.renderer.material.color = Color.red;
		}

		done.renderer.material.color = Color.black;
    }

	void Update() {

		if(timeLimit > 0 && mode == 2) {//animation effect;
			// Decrease timeLimit.
			timeLimit -= Time.deltaTime;
			// Change Color
			bomb.renderer.material.color -= new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
			time.renderer.material.color -= new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
			rotation.renderer.material.color -= new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
			done.renderer.material.color -= new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
		}
		if (timeLimit <= 0 && mode == 2) {
			Application.LoadLevel(0);
		}

	}
    void OnMouseEnter() {
        //renderer.material.color = Color.red;
    }
    void OnMouseOver() {
        //play.renderer.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    }
    void OnMouseExit() {
        //renderer.material.color = Color.red;
    }
    void OnMouseUp() {
        if (this.name == "txt_bomb") {
			if(bombflag == 0){
				bomb.renderer.material.color = Color.red;
				bombflag = 1;
			}
			else{
				bomb.renderer.material.color = Color.grey;
				bombflag = 0;
			}

		}
		if (this.name == "txt_rotation") {
			if(rotationflag == 0){
				rotation.renderer.material.color = Color.red;
				rotationflag = 1;
			}
			else{
				rotation.renderer.material.color = Color.grey;
				rotationflag = 0;
			}
		}
		if (this.name == "txt_time") {
			if(timeflag == 0){
				time.renderer.material.color = Color.red;
				timeflag = 1;
			}
			else{
				time.renderer.material.color = Color.grey;
				timeflag = 0;
			}
			
		}
		if (this.name == "txt_done") {
			mode = 2;
			timeLimit = 1f;
			//done.renderer.material.color = Color.green;
		}
    }

}