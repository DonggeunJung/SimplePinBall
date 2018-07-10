using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingBat : MonoBehaviour {
	public bool isLeft = true;
	int RotateType = 0;
	float fAngleNow = 0;
	float fAngleMax = -60;
	float fAngleUnit = -15;
	int FrameCount = 0;
	float fAngleOrig = 0;

	// Use this for initialization
	void Start () {
		fAngleOrig = transform.localEulerAngles.y;
	}

	// 화면 터치 판단 - 0: None / 1: Left / 2: Right
	int checkScreenTouched() {
		if (RotateType != 0)
			return 0;

		if (Input.GetButtonDown ("Fire1") == false)
			return 0;

		var pos = Input.mousePosition;
		if (pos.x <= Screen.width / 2)
			return 1;
		return 2;
	}

	// Update is called once per frame
	void Update () {
		
		// Left screen side touched
		if ( (isLeft && checkScreenTouched () == 1) || (!isLeft && checkScreenTouched () == 2) ) {
			RotateType = 1;
			fAngleNow = 0;
			FrameCount = 0;

			// Incase Left Bat
			if (isLeft) {
				fAngleMax = -Mathf.Abs(fAngleMax);
				fAngleUnit = -Mathf.Abs(fAngleUnit);
			}
			// Incase Right Bat
			else {
				fAngleMax = Mathf.Abs(fAngleMax);
				fAngleUnit = Mathf.Abs(fAngleUnit);
			}
		}

		if( RotateType == 1 ) {			
			fAngleNow = fAngleUnit;
			FrameCount++;

			if( FrameCount >= 6) {
				Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
				rigidbody.angularVelocity = new Vector3 (0, 0, 0);
				RotateType = 2;
			}
			transform.Rotate(new Vector3(0, fAngleNow, 0));
		}

		if (RotateType == 2) {
			fAngleNow = - fAngleUnit;
			FrameCount--;

			if (FrameCount < 0) {
				Rigidbody rigidbody = transform.GetComponent<Rigidbody> ();
				rigidbody.angularVelocity = new Vector3 (0, 0, 0);
				RotateType = 0;
				FrameCount = 0;
				transform.localRotation = Quaternion.Euler (0,fAngleOrig,0);
				return;
			}
			transform.Rotate (new Vector3 (0, fAngleNow, 0));

		}
	}

}
