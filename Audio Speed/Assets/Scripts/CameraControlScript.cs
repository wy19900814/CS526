﻿using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour {
	
	// Use this for initialization
	GameObject pivot;
	float timeRemaining = 2f;
	State curState = State.WAIT;
	float turnSpeed = 50f;
	
	public AudioClip mafia;
	public AudioClip gonggong;
	public AudioClip fire;
	
	AudioSource audioSource;
	GameObject soundObject;
	
	enum State{
		WAIT,
		ROTATE,
		ROTATE_COMPLETED,
		ROTATE_BACK
	};
	
	public bool startRotate = false;
	
	
	void Start () {
		// Music Play is major in this place
		switch (musicScript.musicflag){
		case 0: AudioSource.PlayClipAtPoint(mafia,transform.position); break;
		case 1: AudioSource.PlayClipAtPoint(gonggong,transform.position); break;
		case 2: AudioSource.PlayClipAtPoint(fire,transform.position); break;
		}
		soundObject = GameObject.Find ("One shot audio");
		audioSource = soundObject.GetComponent<AudioSource> ();
	}
	
	
	void Update () 
	{    
		if (PauseMenuScript.paused)
			audioSource.mute = true;
		else
			audioSource.mute = false;
		
		if (curState == State.WAIT) {
			if(startRotate){
				curState = State.ROTATE;
			}
		}
		else if(curState == State.ROTATE){
			if(isCompleteRotate()){
				curState = State.ROTATE_COMPLETED;
			}
			else{
				RotateDelta ();
			}
		}
		else if(curState == State.ROTATE_COMPLETED){
			timeRemaining -= Time.deltaTime;
			if(timeRemaining <= 0){
				curState = State.ROTATE_BACK;
			}
		}
		else if(curState == State.ROTATE_BACK){
			if(isCompleteRotateBack()){
				timeRemaining = 7f;
				startRotate = false;
				curState = State.WAIT;
				
			}
			else{
				RotateDelta ();
			}
			
		}
		
	}
	
	bool isCompleteRotate (){
		
		if(transform.eulerAngles.y > 180f){
			transform.eulerAngles.Set(transform.eulerAngles.x, 180f, transform.eulerAngles.z);
			return true;
		}
		
		return false;
	}
	
	bool isCompleteRotateBack(){
		if(transform.eulerAngles.y > 358.9f){
			transform.Rotate (Vector3.up, turnSpeed * 0.035f);
			transform.eulerAngles.Set(transform.eulerAngles.x, 0f, transform.eulerAngles.z);
			return true;
		}
		
		return false;
	}
	
	//
	public void RotateDelta () {
		transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
	}
	
	
}