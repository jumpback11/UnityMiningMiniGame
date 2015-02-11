using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float time;

	void Start () {
		Destroy (gameObject, time);
	}

}
