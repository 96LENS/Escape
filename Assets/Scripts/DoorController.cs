using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour {

	public Image indicator;
	public bool opendoor;

	public void InitDoor () {
		this.transform.rotation = Quaternion.Euler (-90.0f,-90.0f, -180.0f);
		opendoor = false;
	}
	
	public void MoveDoor () {
		this.transform.rotation = Quaternion.Euler (-90.0f, 0.0f, -180.0f);
	}

	void AnimateIndicator(bool isOn) {

		if (isOn) {
			indicator.fillAmount += 0.5f * Time.deltaTime;
		} else {
			indicator.fillAmount = 0;
		}	
	}
		

	public void DoorIndicator(GameObject hitObject){

		if (hitObject != null) {

			if (hitObject.tag != "Door") {

				AnimateIndicator (false);
				opendoor = false;

			} else {

				if (opendoor == false) {
					AnimateIndicator (true);
				}

				if (indicator.fillAmount >= 1) {
					opendoor = true;
					indicator.fillAmount = 0;
				}
			}			
		} else {
			AnimateIndicator (false);
		}
	}

}
