/* new script */
using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	private float TRACK_WIDTH = 1.2f;
	private float Y_POSITION = 1.2f;
	private float Z_POSITION = -7.0f;
	
	private float Y_epsilon = 0.1f;
	private float X_epsilon = 0.1f;
	
	CharacterController controller;
	public GameControlScript control;
	
	//jumping control
	private bool inJump = false; //the player is in jump
	private Vector3 jumpDirection = Vector3.zero;
	public float jumpHight = 16.0f;
	
	//lerp example
	public const float smooth = 1.0f;  //must be exact type as delta.time "const float" 
	public const float jumpSpeed = 0.03f;
	private Vector3 newPosition;
	public bool invincible = false;
	private float invincible_timeRemaining = 5f;

	//track current state
	private int curPos = 0; //Mid: 0, Left -1, Right 1;
	
	void Start () {
		controller = GetComponent<CharacterController>();
		newPosition = controller.transform.position;
	}

	void stopInvincibleEffect(){
		animation.Play ("run");
	}

	// Update is called once per frame
	void Update (){
		if(invincible){
			if(invincible_timeRemaining < 0){
				invincible = false;
				invincible_timeRemaining = 5f;
				stopInvincibleEffect();
			}
			else{
				invincible_timeRemaining -= Time.deltaTime;
			}
		}


		if (!inJump) {
			PositionChanging ();
		} else {
			PositionJump();
		}
	}
	
	void PositionJump(){
		Vector3 newPosition = controller.transform.position;
		newPosition.y = Y_POSITION; // move to y position
		controller.transform.position = Vector3.Lerp (controller.transform.position, newPosition, jumpSpeed);
		
		float gravity = 50.0f;
		
		jumpDirection.y -= gravity * Time.deltaTime;       //Apply gravity  
		controller.Move(jumpDirection * Time.deltaTime);      //Move the controller
		
		if(controller.transform.position.y < Y_POSITION + 0.1){
			inJump = false;
		}
	}
	
	//why is isgrounded not working.
	void PositionChanging(){
		Vector3 leftPosition = new Vector3 (-TRACK_WIDTH, Y_POSITION, Z_POSITION );
		Vector3 middlePosition = new Vector3(0.0f, Y_POSITION, Z_POSITION );
		Vector3 rightPosition = new Vector3(TRACK_WIDTH, Y_POSITION, Z_POSITION );
		
		//Debug.Log (controller.isGrounded);
		//old IOS control

		/*
		#if UNITY_IOS
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++; 
		}
		
		if(Input.touchCount > 0){
			if(fingerCount == 1){
				if(Input.GetTouch(0).position.x > (Screen.width / 3 * 2)){
					newPosition = rightPosition;
				}
				else if(Input.GetTouch(0).position.x < (Screen.width / 3 * 1)){
					newPosition = leftPosition;
				}
			}
			else{
				newPosition = middlePosition;
			}
		}
		#endif
	*/

		#if UNITY_IOS
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++; 
		}

//		if(Input.touchCount > 0){
//			if(Input.GetTouch(0).phase == TouchPhase.Began){
//				if(Input.GetTouch(0).position.x > (Screen.width / 3 * 2)){
//					newPosition = rightPosition;
//				}else if(Input.GetTouch(0).position.x < (Screen.width / 3 * 1)){
//					newPosition = leftPosition;
//				}
//			}else if(Input.GetTouch(0).phase == TouchPhase.Ended){
//				if(Input.GetTouch(0).position.x > (Screen.width / 3 * 2) && newPosition == rightPosition){
//					newPosition = middlePosition;
//				}else if(Input.GetTouch(0).position.x < (Screen.width / 3 * 1) && newPosition == leftPosition){
//					newPosition = middlePosition;
//				}
//			}
//		}

		if(Input.touchCount == 1){
			if(Input.GetTouch(0).position.x > (Screen.width / 3 * 2)){
				newPosition = rightPosition;
			}else if(Input.GetTouch(0).position.x < (Screen.width / 3 * 1)){
				newPosition = leftPosition;
			}
		}else if(Input.touchCount == 2){
			if(Input.GetTouch(0).position.x > (Screen.width / 3 * 2) && Input.GetTouch(1).position.x < (Screen.width / 3 * 1)){
				newPosition = leftPosition;
			}else if(Input.GetTouch(1).position.x > (Screen.width / 3 * 2) && Input.GetTouch(0).position.x < (Screen.width / 3 * 1)){
				newPosition = rightPosition;
			}
		}else if(Input.touchCount == 0){
			newPosition = middlePosition;
		}
		#endif



		//old control logic 04/28

		if (Input.GetButton ("Jump")) {          //play "Jump" animation if character is grounded and spacebar is pressed
						//animation.Stop("run");
						animation.Play ("jump_pose");
						//transform.Translate(Vector3.up * 90, Space.World)
						jumpDirection.y = 16.0f;
			
						//controller.transform.Translate(Vector3.up * 5.0f); //add the jump height to the character
						inJump = true;
						return;
			
				} else if (Input.GetKeyDown (KeyCode.LeftArrow))
						newPosition = leftPosition;
				else if (Input.GetKeyDown (KeyCode.RightArrow))
						newPosition = rightPosition;
				else if (Input.GetKeyUp (KeyCode.LeftArrow) && newPosition == leftPosition)
						newPosition = middlePosition;
				else if (Input.GetKeyUp (KeyCode.RightArrow) && newPosition == rightPosition)
						newPosition = middlePosition;

		
		controller.transform.position = Vector3.Lerp (controller.transform.position, newPosition, smooth);

		
		if (!invincible && controller.transform.position.y <= 1.5f) {
			animation.Play ("run");
		}
	}
	
	void OnTriggerEnter(Collider other)
	{               
		Debug.Log ("Object Script" + other.gameObject.GetComponent<PowerupScript> ());

		if (!invincible || (invincible && (other.gameObject.GetComponent<PowerupScript> () != null))) {
			other.gameObject.GetComponent<ItemScript> ().getEffects (control);
		} 
	

		Destroy(other.gameObject);
		
	}

	private void OnGUI(){
		Rect left = new Rect (Screen.width / 30, Screen.height / 5 * 4, Screen.width / 10, Screen.height / 10);
		Rect right = new Rect (Screen.width - Screen.width / 15 * 2, Screen.height / 5 * 4, Screen.width / 10, Screen.height / 10);

		if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 30, Screen.height / 5 * 4, Screen.width / 10, Screen.height / 10), "Jump")) {          //play "Jump" animation if character is grounded and spacebar is pressed
						//animation.Stop("run");
						animation.Play ("jump_pose");
						//transform.Translate(Vector3.up * 90, Space.World)
						jumpDirection.y = 16.0f;
			
						//controller.transform.Translate(Vector3.up * 5.0f); //add the jump height to the character
						inJump = true;
						return;
		} else if (GUI.Button (left, "Left")) {
		
		} else if (GUI.Button (right, "Right")) {

		}
		
		
	}
}
