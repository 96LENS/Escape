using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField] private GameObject tvscreen, text;
	[SerializeField] public Text lecturetext;
	[SerializeField] private GameObject times;
	[SerializeField] public Text Timer;
	[SerializeField] private GameObject keys;
	[SerializeField] private Image redkey, bluekey, goldkey;
	[SerializeField] private GameObject pcscreen, pcbutton;
	[SerializeField] private Text pctext;
	[SerializeField] private GameObject View;

	public void InitUI(){
		tvscreen.SetActive (false);
		text.SetActive (false);
		lecturetext.text = "";
		times.SetActive (false);
		keys.SetActive (false);
		pcscreen.SetActive (false);
		pcbutton.SetActive (false);
		pctext.text = "";
		View.SetActive (false);
	}

	public void StartUI(){
		text.SetActive (false);
		times.SetActive (true);
		keys.SetActive (true);
	}

	public void OnTv(){
		tvscreen.SetActive (true);
		text.SetActive (true);
	}

	public void OnPc(){
		pcbutton.SetActive (false);
		pcscreen.SetActive (true);
		pctext.text = "部屋のどこかに鍵が出現した";
	}

	public void AppearPcSwitch(){
		pcbutton.SetActive (true);
	}

	public void DisappearPcSwitch(){
		pcscreen.SetActive (false);
		pcbutton.SetActive (false);
	}

	public void TimeUpdate(float m, float s){

		Timer.text = m.ToString ("00") + ":" + s.ToString ("00");
	}

	public void GetRedkey(){
		Sprite red = Resources.Load("Sprites/redkey", typeof(Sprite)) as Sprite;
		redkey.sprite = red;
	}

	public void GetBluekey(){
		Sprite blue = Resources.Load("Sprites/bluekey", typeof(Sprite)) as Sprite;
		bluekey.sprite = blue;
	}

	public void GetGoldkey(){
		Sprite gold = Resources.Load("Sprites/goldkey", typeof(Sprite)) as Sprite;
		goldkey.sprite = gold;
	}

	public void DoorView() {
		View.SetActive (true);
	}

	public void TimeupUi (){
		text.SetActive (true);
		times.SetActive (false);
		keys.SetActive (false);
	}
}