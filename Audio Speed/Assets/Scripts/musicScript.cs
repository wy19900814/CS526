using UnityEngine;
using System.Collections;

public class musicScript : MonoBehaviour {
    public Renderer rend;

	public int mode = 0;
	public GameObject music1;
	public GameObject music2;
	public GameObject music3;
	//public GameObject import;
	public GameObject done;

	public static int musicflag = 0;
	static float timeLimit = 0; 
	float moveSpeed = 0.15f;

    void Start() {
        rend = GetComponent<Renderer>();
		music1 = GameObject.Find("txt_music1");
		music2 = GameObject.Find("txt_music2");
		music3 = GameObject.Find("txt_music3");
		//import = GameObject.Find("txt_import");
		done = GameObject.Find("txt_done");

		music3.renderer.material.color = Color.red;
		music2.renderer.material.color = Color.red;
		music1.renderer.material.color = Color.red;
		//import.renderer.material.color = Color.grey;

		done.renderer.material.color = Color.black;
    }

	void Update() {

		if(timeLimit > 0 && mode == 2) {//animation effect;
			// Decrease timeLimit.
			timeLimit -= Time.deltaTime;
			// Change Color
			music1.renderer.material.color -= new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
			music2.renderer.material.color -= new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
			music3.renderer.material.color -= new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
			//import.renderer.material.color -= new Color(0.1F, 0.1F, 0.1F) * Time.deltaTime;
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
        if (this.name == "txt_music1") {
			musicflag = 0;
			Application.LoadLevel(3);
		}
		if (this.name == "txt_music2") {
			musicflag = 1;
			Application.LoadLevel(3);
		}
		if (this.name == "txt_music3") {
			musicflag = 2;
			Application.LoadLevel(3);
		}
		if (this.name == "txt_done") {
			mode = 2;
			timeLimit = 1f;
			//done.renderer.material.color = Color.green;
		}
    }

}