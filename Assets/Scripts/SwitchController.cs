using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchController : MonoBehaviour {

	public Image OnSwitch, Onindicator, OffSwitch, Offindicator;
	public bool onClicked, offClicked;

	void OnAnimateIndicator(bool isOn) {

		if (isOn) {
			Onindicator.fillAmount += 0.6f * Time.deltaTime;
		} else {
			Onindicator.fillAmount = 0;
		}	
	}

	public void OnPlayIndicator(GameObject hitObject){

		if (hitObject != null) {

			if (hitObject.tag != "ON" || onClicked == true) {
				OnAnimateIndicator (false);

			} else {
				if (onClicked == false) {
					OnAnimateIndicator (true);
				}

				if (Onindicator.fillAmount >= 1) {
					onClicked = true;
					offClicked = false;
					Onindicator.fillAmount = 0;
					OnSwitch.color = new Color (1.0f, 85.0f / 255.0f, 85.0f / 255.0f);
					OffSwitch.color = new Color (25.0f / 255.0f, 41.0f / 255.0f, 86.0f / 255.0f);
				}
			}
		} else {
			OnAnimateIndicator (false);
		}
	}

	void OffAnimateIndicator(bool isOn) {

		if (isOn) {
		    Offindicator.fillAmount += 0.6f * Time.deltaTime;
		} else {
			Offindicator.fillAmount = 0;
		}	
	}

	public void OffPlayIndicator(GameObject hitObject){

		if (hitObject != null) {
			
			if (hitObject.tag != "OFF" || offClicked == true) {
				OffAnimateIndicator (false);

			} else {
				if (offClicked == false) {
					OffAnimateIndicator (true);
				}

				if (Offindicator.fillAmount >= 1) {
					offClicked = true;
					onClicked = false;
					Offindicator.fillAmount = 0;
					OnSwitch.color = new Color (96.0f / 255.0f, 32.0f / 255.0f, 32.0f / 255.0f);
					OffSwitch.color = new Color (71.0f / 255.0f, 107.0f / 255.0f, 244.0f / 255.0f);
				}
			}
		} else {
			OffAnimateIndicator (false);
		}
	}

	public void InitSwitch(){
		onClicked = false;
		offClicked = true;
		Onindicator.fillAmount = 0;
		Offindicator.fillAmount = 0;
		OnSwitch.color = new Color(96.0f/255.0f, 32.0f/255.0f, 32.0f/255.0f);
		OffSwitch.color = new Color (71.0f/255.0f, 107.0f/255.0f, 244.0f/255.0f);
	}
}
