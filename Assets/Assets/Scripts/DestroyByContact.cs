using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject audio;


	void OnTriggerEnter(Collider other) {

		Instantiate (audio, transform.position, transform.rotation);
		Destroy (gameObject);

		
	}
}
