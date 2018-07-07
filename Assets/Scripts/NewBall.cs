using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBall : MonoBehaviour {

	public GameObject ballPrefab;
	GameObject ballNow = null;
	public float shotSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		Shot ();
	}
	
	// Update is called once per frame
	void Update () {
		if ( ballNow.transform.position.y < -4) {
			Destroy (ballNow);
			Shot ();
		}
	}

	void Shot () {

		ballNow = (GameObject)Instantiate (
			ballPrefab,
			transform.position,
			Quaternion.identity
		                  );

		Rigidbody ballRigidbody = ballNow.GetComponent<Rigidbody> ();
		ballRigidbody.AddForce (transform.forward * shotSpeed);
	}

}
