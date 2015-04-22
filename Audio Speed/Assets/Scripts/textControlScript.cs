using UnityEngine;
using System.Collections;

public class textControlScript : MonoBehaviour {
    public Renderer rend;

	public GameObject play;
	public GameObject quit;
	public GameObject challenge;
	public GameObject bomb;
	public GameObject time;
	public GameObject rotation;

    public static int mode = 0;// 0: enter the scene 1:game start 2:challenge

	static float timeLimit = 0; 
	float moveSpeed = 0.5f;

    void Start() {
        rend = GetComponent<Renderer>();
		play = GameObject.Find("txt_play");
		quit = GameObject.Find("txt_quit");
		challenge = GameObject.Find("txt_challenge");
		//bomb = GameObject.Find("txt_bomb");
		//time = GameObject.Find("txt_time");
		//rotation = GameObject.Find("txt_rotation");
		//renderer.material.color = new Color (0, 0, 0);
		//bomb.active = false;
		//time.active = false;
		//rotation.active = false;
    }
	void Update() {

		if (mode == 0) {
			play.renderer.material.color += new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
			quit.renderer.material.color += new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
			challenge.renderer.material.color += new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
		}

		if(timeLimit > 0 && mode == 1) {//animation effect;
			// Decrease timeLimit.
			timeLimit -= Time.deltaTime;
			// Change Color
			challenge.renderer.material.color -= new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
			quit.renderer.material.color -= new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
			//play.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
			
			
		}
		if (timeLimit <= 0 && mode == 1) {
			mode = 0;
			Application .LoadLevel(2);
			
		}

		if(timeLimit > 0 && mode == 2) {//animation effect;
			// Decrease timeLimit.
			timeLimit -= Time.deltaTime;
			// Change Color
			play.renderer.material.color -= new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
			quit.renderer.material.color -= new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
			challenge.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);


		}
		if (timeLimit <= 0 && mode == 2) {
			mode = 0;
			Application .LoadLevel(1);
		
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
        if (this.name == "txt_play") {
			timeLimit = 5f;
			mode = 1;
		}
		if (this.name == "txt_challenge") {
			timeLimit = 5f;
			mode = 2;
		}
		if (this.name == "txt_quit") {
			Application.Quit();
		}
    }

	void destroyMeny(){

	}
}