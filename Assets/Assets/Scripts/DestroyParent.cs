using UnityEngine;
using System.Collections;

public class DestroyParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.DetachChildren ();
		Destroy (gameObject);
	}
	

}
