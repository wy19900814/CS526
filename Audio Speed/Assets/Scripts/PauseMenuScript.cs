using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour 
{
	public GUISkin myskin;  //custom GUIskin reference
	public string levelToLoad;
	public static bool paused = false;
	
	private void Start()
	{
		Time.timeScale=1; //Set the timeScale back to 1 for Restart option to work  
	}
	
	private void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Escape) ) //check if Escape key/Back key is pressed
		{
			if (paused)
				paused = false;  //unpause the game if already paused
			else
				paused = true;  //pause the game if not paused
		}
		
		if(paused)
			Time.timeScale = 0;  //set the timeScale to 0 so that all the procedings are halted
		else
			Time.timeScale = 1;  //set it back to 1 on unpausing the game
		
	}
	
	private void OnGUI()
	{
		//GUI.skin=myskin;   //use the custom GUISkin

		if(GUI.Button(new Rect(Screen.width/30, Screen.height/30 + 30, Screen.width/15, Screen.height/15),"Pause")){
			paused = true;
		}
		
		if (paused){    

			GUIStyle myStyle = new GUIStyle();
			myStyle.fontSize = 80;
			Color myColor = new Color(1.0f, 0.5f, 0.016f, 1.0f);
			myStyle.normal.textColor = myColor;

			GUI.Box(new Rect(Screen.width/3, Screen.height/6, Screen.width/2, Screen.height/2), "  PAUSED",myStyle);
			//GUI.Label(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "YOUR SCORE: "+ ((int)score));
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESUME")){
				paused = false;
			}
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESTART")){
				Application.LoadLevel(Application.loadedLevel);
			}
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "MAIN MENU")){
				paused = false;
				Application.LoadLevel(0);
			} 
		}
	}
}