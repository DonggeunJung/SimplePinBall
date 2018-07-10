using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour {
	public string BatTag1;
	public string BatTag2;
	public string BatTag3;

	void OnCollisionEnter(Collision collision) {
		ContactPoint contact = collision.contacts [0];

		if (collision.collider.tag == BatTag1 || collision.collider.tag == BatTag2
			|| collision.collider.tag == BatTag3) {
			addVelocity(contact.point);
		}
	}

	void addVelocity(Vector3 contactPoint) {
		Vector3 direction = new Vector3 (-contactPoint.x, -contactPoint.y, -contactPoint.z);
		Rigidbody r = this.GetComponent<Rigidbody> ();
		r.AddForce (direction * r.mass * 350.0f);
	}
}
