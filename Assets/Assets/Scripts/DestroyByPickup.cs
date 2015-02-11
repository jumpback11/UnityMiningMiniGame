using UnityEngine;
using System.Collections;

public class DestroyByPickup : MonoBehaviour {


	public int scoreValue;
	public GameObject replacement;
	private GameController gameController;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log ("cannot find 'GameController' script");
		}
	}
	void OnTriggerEnter(Collider other) {

		gameController.AddScore (scoreValue);
		Instantiate (replacement, transform.position, transform.rotation);
		Destroy (gameObject);
				
	}
}
