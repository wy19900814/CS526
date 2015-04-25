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
	public const float jumpSpeed = 0.05f;
	private Vector3 newPosition;
	public bool invincible = false;
	private float invincible_timeRemaining = 5f;


	//audios
	public AudioClip bloop;
	public AudioClip blurp;
	
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
		
		float gravity = 20.0f;
		
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
		
		#if UNITY_IOS
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++; 
		}
		
		if(Input.touchCount > 0){
			if (fingerCount == 2){
				//animation.Stop("run");
				animation.Play("jump_pose");
				//transform.Translate(Vector3.up * 90, Space.World)
				jumpDirection.y = 16.0f;
				
				//controller.transform.Translate(Vector3.up * 5.0f); //add the jump height to the character
				inJump = true;
				return;
			}
			else if(fingerCount == 1){
				if(Input.GetTouch(0).position.x > (Screen.height / 2)){
					newPosition = rightPosition;
				}
				else{
					newPosition = leftPosition;
				}
			}
			else{
				newPosition = middlePosition;
			}
		}
		#endif
		
		
		if (Input.GetButton ("Jump")) {          //play "Jump" animation if character is grounded and spacebar is pressed
			//animation.Stop("run");
			animation.Play("jump_pose");
			//transform.Translate(Vector3.up * 90, Space.World)
			jumpDirection.y = 16.0f;
			
			//controller.transform.Translate(Vector3.up * 5.0f); //add the jump height to the character
			inJump = true;
			return;
			
		}else if (Input.GetKeyDown (KeyCode.LeftArrow))
			newPosition = leftPosition;
		else if (Input.GetKeyDown (KeyCode.RightArrow))
			newPosition = rightPosition;
		else if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow))
			newPosition = middlePosition;
		
		controller.transform.position = Vector3.Lerp (controller.transform.position, newPosition, smooth);
		//Debug.Log ("curr position" + controller.transform.position.ToString ());
		//Debug.Log ("new position" + newPosition.ToString ());
		//controller.transform.Translate(Vector3.down * 0.01f); //cannot put too large or the character falls at first stage
		
		//change character animation
		
		if (!invincible && controller.transform.position.y <= 1.5f) {
			animation.Play ("run");
			
			/*if(newPosition == leftPosition && controller.transform.position != leftPosition){
				animation.Play ("idle");
			}else if (newPosition == rightPosition && controller.transform.position != rightPosition) {
				animation.Play ("idle");		
			}else if(newPosition == middlePosition && controller.transform.position != middlePosition) {
				animation.Play ("idle");
			}else{
				//keep running
			}*/
		}
	}
	
	void OnTriggerEnter(Collider other)
	{               
		/*if(other.gameObject.name == "Powerup(Clone)")
		{

			other.gameObject.GetComponent<ItemScript>().getEffects(control);
			control.PowerupCollected();
			audio.PlayOneShot(blurp);
		}
		else if(other.gameObject.name == "Obstacle(Clone)")
		{
			Debug.Log ("Power down");
			control.AlcoholCollected();
			audio.PlayOneShot(bloop);
		}*/
		Debug.Log ("Object Script" + other.gameObject.GetComponent<PowerupScript> ());

		if (!invincible || (invincible && (other.gameObject.GetComponent<PowerupScript> () != null))) {
			other.gameObject.GetComponent<ItemScript> ().getEffects (control);
		} 
	

		Destroy(other.gameObject);
		
	}
}
