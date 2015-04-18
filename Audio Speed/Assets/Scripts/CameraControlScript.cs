using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour {

	// Use this for initialization
	GameObject pivot;
	float timeRemaining = 2f;
	State curState = State.WAIT;
	float turnSpeed = 50f;

	public AudioClip mafia;
	public AudioClip gonggong;

	enum State{
		WAIT,
		ROTATE,
		ROTATE_COMPLETED,
		ROTATE_BACK
	};

	public bool startRotate = false;


	void Start () {
		AudioSource.PlayClipAtPoint(mafia,transform.position);
	}

	
	void Update () 
	{
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
