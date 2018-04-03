using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] EyeController eyeController;

	public Camera mainCamera;
	public Transform camera_trans;
	public float velocity, minAngle, maxAngle;
	public GameObject hitObject;
	private CharacterController characterController;

	void Start () {
		characterController = GetComponent<CharacterController> ();
	}

	void FixedUpdate () {

		GetLookObject ();
		eyeController.PlayIndicator (hitObject);

		float x = mainCamera.transform.eulerAngles.x;

		if (minAngle < x && x < maxAngle) {
			Move ();
		}
	
		if (Input.GetKeyDown(KeyCode.R)){
			ResetPosition ();
		}

		if (transform.position.y >= 1.7 || transform.position.y <= 1.5) {
			Vector3 pos = transform.position;
			pos.y = 1.65f;
			transform.position = pos;
		}
	}

	void Move (){
		Vector3 moveDirection = mainCamera.transform.forward;
		moveDirection *= velocity * Time.deltaTime; 
		moveDirection.y = 0.0f;
		characterController.Move (moveDirection);
	}

	void GetLookObject() {
		Ray ray;
		RaycastHit hit;

		ray = new Ray (camera_trans.position, camera_trans.rotation * Vector3.forward * 100.0f);

		if (Physics.Raycast (ray, out hit)) {
			hitObject = hit.collider.gameObject;
		} else {
			hitObject = null;
		}
	}

	public void ResetPosition(){
		transform.position = new Vector3 (-0.43f, 1.65f, 3.1f);
	}
}
