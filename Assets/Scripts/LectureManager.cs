using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureManager : MonoBehaviour {

	[SerializeField] AudioManager audioManager;
	[SerializeField] UIManager uiManager;
	[SerializeField] ObjectManager objectManager;
	[SerializeField] PlayerController playerController;

	public float interval, Ginterval;
	public bool lecturemove, getsphere, lecturefinish, timeupfinish;
	private bool isRunning;

	IEnumerator LectureMove(){

		if (isRunning == true || lecturemove == true) {
			yield break;
		} else {
			isRunning = true;
			uiManager.lecturetext.text = "VRの世界へようこそ！";
			yield return new WaitForSeconds (interval);
			uiManager.lecturetext.text = "ここはVRで作られた部屋です";
			yield return new WaitForSeconds (interval);
			uiManager.lecturetext.text = "これから操作方法を説明します";
			yield return new WaitForSeconds (interval);
			uiManager.lecturetext.text = "下を向くと歩くことができます";
			yield return new WaitForSeconds (interval);
			uiManager.lecturetext.text = "実際に動いてみてください";
			yield return new WaitForSeconds (interval * 3);
			playerController.ResetPosition ();
			uiManager.lecturetext.text = "動くことができましたね";
			yield return new WaitForSeconds (interval);
			uiManager.lecturetext.text = "目の前に球を用意しました";
			objectManager.AppearSphere ();
			audioManager.PlayAppear ();
			yield return new WaitForSeconds (interval - 1);
			uiManager.lecturetext.text = "球を見つめてください";
			isRunning = false;
			lecturemove = true;
		} 
	}

	IEnumerator LectureGet(){

		if (isRunning == true || lecturefinish == true) {
			yield break;
		} else {
			isRunning = true;
			uiManager.lecturetext.text = "球を取ることができましたね";
			yield return new WaitForSeconds (interval);
			uiManager.lecturetext.text = "特定のモノを見つめると取ることができます";
			yield return new WaitForSeconds (interval);
			uiManager.lecturetext.text = "これからこの部屋に隠されている";
			yield return new WaitForSeconds (interval);
			uiManager.lecturetext.text = "3つの鍵を見つけなければなりません";
			yield return new WaitForSeconds (interval);
			uiManager.lecturetext.text = "さっそく鍵を探してみましょう";
			yield return new WaitForSeconds (interval);
			uiManager.lecturetext.text = "スタート！！";
			yield return new WaitForSeconds (interval);
			isRunning = false;
			lecturefinish = true;
		}
	}

	IEnumerator Timeup(){

		if (isRunning == true || timeupfinish == true) {
			yield break;
		} else {
			isRunning = true;
			uiManager.lecturetext.text = "TIMEUP";
			yield return new WaitForSeconds (Ginterval);
			uiManager.lecturetext.text = "鍵を全部見つけられなかったね";
			yield return new WaitForSeconds (Ginterval);
			uiManager.lecturetext.text = "これで体験は終了するよ";
			yield return new WaitForSeconds (Ginterval);
			uiManager.lecturetext.text = "また遊んでね";
			yield return new WaitForSeconds (Ginterval);
			isRunning = false;
			timeupfinish = true;
		}
	}


	public void LectureOne(){
		StartCoroutine ("LectureMove");
	}

	public void LectureTwo() {
		StartCoroutine ("LectureGet");
	}



	public void TimeupTime() {
		StartCoroutine ("Timeup");
	}

	public void InitLecture(){
		isRunning = false;
		getsphere = false;
		lecturemove = false;
		lecturefinish = false;
		timeupfinish = false;
	}
}
