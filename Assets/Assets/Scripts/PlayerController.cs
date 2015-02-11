using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	private static Vector3 currentPosition;
	private static Quaternion currentRotation;
	public RaycastHit hit;
	private bool left, right, forward, back;
	public GameObject moveAudio;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log ("cannot find 'GameController' script");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameController.gameover) {
			Movement ();
			left = rigidbody.SweepTest (Vector3.left, out hit, 0.5f);
			right = rigidbody.SweepTest (Vector3.right, out hit, 0.5f);
			forward = rigidbody.SweepTest (Vector3.forward, out hit, 0.5f);
			back = rigidbody.SweepTest (Vector3.back, out hit, 0.5f);
		}
	}


	void Move(int X, int Z)
	{
		int x = X;
		int z = Z;

		// Modify position
		transform.position = RoundVector(new Vector3 
			(transform.position.x + x, transform.position.y, transform.position.z + z));
		//save position
		Vector3 v3 = RoundVector(new Vector3(transform.position.x, transform.position.y, transform.position.z));
		currentPosition = RoundVector(v3);
		Instantiate (moveAudio, transform.position, transform.rotation);
		gameController.UseMove ();
		
	}

	void Rotate(float Y)
	{
		float angle = Y;

		//Reset Rotation
		transform.rotation = new Quaternion (0, 0, 0, 0);
		//Rotate to match direction
		transform.Rotate (Vector3.up * angle, Space.Self);
		//Save rotation
		currentRotation = transform.rotation;
	}

	void OnTriggerEnter(Collider other) {


	}


	Vector3 RoundVector(Vector3 v)
	{
		//round numbers to whole numbers
		return new Vector3 (Mathf.RoundToInt (v.x), Mathf.RoundToInt (v.y), Mathf.RoundToInt (v.z));
	}

	void Movement()
	{
		//Move/rotate directions based on key pressed and if on grid
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {
			if(!left){
				// Move Left
				Move (-1, 0);
			}else{
			transform.position = RoundVector(currentPosition);
			}
			Rotate(270);
			
		} else if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {
			if(!right){
				// Move Right
				Move (1, 0);
			}else{
			transform.position = RoundVector(currentPosition);
			}
			Rotate(90);
			
		} else if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
			if(!forward){
				// Move Up
				Move (0, 1);
			}else{
			transform.position = RoundVector(currentPosition);
			}
			Rotate(0);
			
		} else if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {
			if(!back){
				// Move Down
				Move (0, -1);
			}else{
			transform.position = RoundVector(currentPosition);
			}
			Rotate(180);
			
		} else {
			//stay still
			transform.position = RoundVector(currentPosition);
			transform.rotation = currentRotation;
		}
	}
}
