using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	[SerializeField] UIManager uiManager;

	public bool timeup;
	private float minutes, seconds, oldseconds;

	public void TimeCalculate (){

		seconds -= Time.deltaTime;

		if (seconds <= 0f) {
			minutes--;
			seconds = 59;
		}

		if (minutes <= 0) {
			timeup = true;
			uiManager.TimeUpdate(0, 0);
			return;
		}

		if (seconds != oldseconds){
			uiManager.TimeUpdate (minutes, seconds);
		}

		oldseconds = seconds;
	}

	public void InitTimer(){

		minutes = 0;
		seconds = 0;
		oldseconds = 0;
		timeup = false;
		uiManager.TimeUpdate (minutes, seconds);
	}

	public void StartTimer(float time)
	{
		minutes = time / 60;
		seconds = time % 60;
		oldseconds = 0.0f;
	}
}
