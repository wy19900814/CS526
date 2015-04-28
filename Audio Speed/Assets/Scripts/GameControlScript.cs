using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {
	
	public GUISkin skin;
	float timeRemaining = 210;
	float timeExtension = 3f;
	float timeDeduction = 2f;
	float totalTimeElapsed = 0;
	float score=0f;
	int highest;
	public bool isGameOver = false;
	public bool rotateCamera = false;

	public CameraControlScript cameraController;
	public PlayerControl playerController;

	Material Sunny01A;
	Material Night01A;

	private const string FACEBOOK_APP_ID = "1631504580413971";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
	
	void ShareToFacebook (string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter, string redirectParameter)
	{
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
		                     "&link=" + WWW.EscapeURL(linkParameter) +
		                     "&name=" + WWW.EscapeURL(nameParameter) +
		                     "&caption=" + WWW.EscapeURL(captionParameter) + 
		                     "&description=" + WWW.EscapeURL(descriptionParameter) + 
		                     "&picture=" + WWW.EscapeURL(pictureParameter) + 
		                     "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}

	void Start(){
		Sunny01A = Resources.Load("Sunny 01A", typeof(Material)) as Material;
		Night01A = Resources.Load("Night 01A", typeof(Material)) as Material;
		RenderSettings.skybox = Sunny01A;
		Time.timeScale = 1;  // set the time scale to 1, to start the game world. This is needed if you restart the game from the game over menu

		challengeScript.timeflag = 1;//jerry debug
		if (challengeScript.timeflag > 0) {
			timeRemaining = 1;//jerry debug
		} 
		else {
			timeRemaining = SpawnScript.musicTotalTime [musicScript.musicflag];
		}
	}

	public void addScore(int delta){
		if(!isGameOver)
			score += delta;
	}

	public void addTime(int delta){
		timeRemaining += delta;
	}

	public float getTime (){
		return timeRemaining;
	}

	void Update () { 
		if (isGameOver)
			return;
		
		totalTimeElapsed += Time.deltaTime;
		timeRemaining -= Time.deltaTime;
		if(timeRemaining <= 0){
			isGameOver = true;
		}
	}
	
	void OnGUI()
	{
		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = 30;
		Color myColor = new Color(1.0f, 0.5f, 0.016f, 1.0f);
		myStyle.normal.textColor = myColor;

		//GUI.skin=skin; //use the skin in game over menu
		//check if game is not over, if so, display the score and the time left
		if(!isGameOver)    
		{
			GUI.Label(new Rect(10, 10, Screen.width/5, Screen.height/6),"TIME LEFT: "+((int)timeRemaining).ToString());
			GUI.Label(new Rect(Screen.width-(Screen.width/6), 10, Screen.width/6, Screen.height/6), "SCORE: "+((int)score).ToString());
		}
		//if game over, display game over menu with score
		else
		{
			//Time.timeScale = 0; //set the timescale to zero so as to stop the game world
			
			//display the final score
			highest = PlayerPrefs.GetInt("Player Score");
			if(score>=highest){
				PlayerPrefs.SetInt("Player Score", (int)score);
				GUI.Box(new Rect((int)(Screen.width/2.5), Screen.height/7, Screen.width/2, Screen.height/2), "New Highest Score! \nYOUR SCORE: "+(int)score+ "\nHighest Score:" + highest,myStyle);
				Debug.Log(highest);
			}
			else{
				GUI.Box(new Rect((int)(Screen.width/2.5), Screen.height/7, Screen.width/2, Screen.height/2), "Game Over! \nYOUR SCORE: "+(int)score+ "\nHighest Score:" + highest,myStyle);
			}
			
			//restart the game on click
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESTART")){
				Application.LoadLevel(Application.loadedLevel);
			}
			
			//load the main menu, which as of now has not been created
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "MAIN MENU")){
				Time.timeScale = 1;
				Application.LoadLevel(0);
			}
			
			//exit the game
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "SHARE SCORE")){
				ShareToFacebook("http://www-scf.usc.edu/~xiongfeg/","I'm playing Audio Speed!","New High Score!","1000","http://www-scf.usc.edu/~xiongfeg/images/photo.jpg","http://www-scf.usc.edu/~xiongfeg/");
			}
		}
	}
}