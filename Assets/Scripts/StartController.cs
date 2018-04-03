using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour {

	public Transform camera_trans;
	public Image startindicator;
	private GameObject hitObject;
	private bool startClicked;
	public AudioSource audio;
	public AudioClip select , load;

	void start(){
		InitStart ();
	}

	void FixedUpdate(){

		GetLookObject ();
		StartPlayIndicator (hitObject);;
	}

	void StartAnimateIndicator(bool isOn) {

		if (isOn) {
			startindicator.fillAmount += 0.4f * Time.deltaTime;
		} else {
			startindicator.fillAmount = 0;
		}	
	}

	void StartPlayIndicator(GameObject hitObject){

		if (hitObject != null) {
			
			if (hitObject.tag != "Start") {
				StartAnimateIndicator (false);
				startClicked = false;

			} else {

				if (startClicked == false) {
					audio.PlayOneShot (load);
					StartAnimateIndicator (true);
				}

				if (startindicator.fillAmount >= 1) {
					startClicked = true;
					startindicator.fillAmount = 0;
				}

				if (startClicked) {
					audio.PlayOneShot (select);
					SceneManager.LoadScene ("Main");
				}
			}	
		} else {
			StartAnimateIndicator (false);
		}
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

	void InitStart(){
		startindicator.fillAmount = 0;
	}
}
