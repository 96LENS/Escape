using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

	public Image tvindicator, pcindicator;
	public bool tvClicked, pcClicked;
	private bool altvClicked, alpcClicked;

	void TvAnimateIndicator(bool isOn) {

		if (isOn) {
			tvindicator.fillAmount += 0.6f * Time.deltaTime;
		} else {
			tvindicator.fillAmount = 0;
		}	
	}

	public void TvPlayIndicator(GameObject hitObject){

		if (hitObject != null) {
			
			if (hitObject.tag != "TV" || altvClicked == true) {
				TvAnimateIndicator (false);

			} else {
				
				if (alpcClicked == false) {
					TvAnimateIndicator (true);
				}

				if (tvindicator.fillAmount >= 1) {
					tvClicked = true;
					altvClicked = true;
					tvindicator.fillAmount = 0;
				}
			}
		} else {
			TvAnimateIndicator (false);
			tvClicked = false;
		}
	}

	void PcAnimateIndicator(bool isOn) {

		if (isOn) {
			pcindicator.fillAmount += 0.6f * Time.deltaTime;
		} else {
			pcindicator.fillAmount = 0;
		}	
	}

	public void PcPlayIndicator(GameObject hitObject){

		if (hitObject != null) {

			if (hitObject.tag != "PC" || alpcClicked == true) {
				PcAnimateIndicator (false);

			} else {

				if (alpcClicked == false) {
					PcAnimateIndicator (true);
				}

				if (pcindicator.fillAmount >= 1) {
					pcClicked = true;
					alpcClicked = true;
					pcindicator.fillAmount = 0;
				}
			}
		} else {
			PcAnimateIndicator (false);
			pcClicked = false;
		}
	}

	public void InitButton (){
		tvClicked = false;
		pcClicked = false;
		tvindicator.fillAmount = 0;
		pcindicator.fillAmount = 0;
	}
}
