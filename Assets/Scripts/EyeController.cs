using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeController : MonoBehaviour {

	public Image indicator;
	public float filltime;
	public bool hasClicked;

	void AnimateIndicator(bool isOn) {

		if (isOn) {
			indicator.fillAmount += filltime * Time.deltaTime;
		} else {
			indicator.fillAmount = 0;
		}	
	}

	public void PlayIndicator(GameObject hitObject){

		if (hitObject != null) {
			if (hitObject.tag != "GetObj") {
				AnimateIndicator (false);
				hasClicked = false;
		
			} else {
			
				if (hasClicked == false) {
					AnimateIndicator (true);
				}

				if (indicator.fillAmount >= 1) {
					hasClicked = true;
					indicator.fillAmount = 0;
				}
			}
		} else {
			AnimateIndicator(false);
			hasClicked = false;
		}			
	}

	public void InitEye (){
		hasClicked = false;
		indicator.fillAmount = 0;
	}
}
