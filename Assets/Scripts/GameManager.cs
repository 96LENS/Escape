using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField] AudioManager audioManager;
	[SerializeField] ButtonController buttonController;
	[SerializeField] EyeController eyeController;
	[SerializeField] DoorController door;
	[SerializeField] LectureManager lectureManager;
	[SerializeField] ObjectManager objectManager;
	[SerializeField] PlayerController playerController;
	[SerializeField] SwitchController switchController;
	[SerializeField] TimeManager timeManager;
	[SerializeField] UIManager uiManager;

	public enum GameState {
        INIT,
        LECTURE,
        START,
        PLAY,
        TIMEUP,
		CLEAR,
    }

    public GameState gameState;
	public float playtime;
	private bool red, blue, gold, isRunning;

	void Start(){		
		gameState = GameState.INIT;
	}

	void FixedUpdate () {
		ResetScene ();

		switch (gameState) {

		case GameState.INIT:
			InitGameManager ();
			audioManager.InitAudio ();
			eyeController.InitEye ();
			door.InitDoor ();
			lectureManager.InitLecture ();
			objectManager.InitObject ();
			playerController.ResetPosition ();
			switchController.InitSwitch ();
			timeManager.InitTimer ();
			uiManager.InitUI ();
			gameState = GameState.LECTURE;
			break;

		case GameState.LECTURE:
			
			buttonController.TvPlayIndicator (playerController.hitObject);

			if (buttonController.tvClicked == true) {
				audioManager.PlayTvButton ();
				uiManager.OnTv ();
				lectureManager.LectureOne ();
			}

			if (eyeController.hasClicked == true) {
				audioManager.PlayGet ();
				objectManager.DestroyObject (playerController.hitObject);
				lectureManager.getsphere = true;
			}

			if (lectureManager.getsphere) {
				lectureManager.LectureTwo ();
			}

			if (lectureManager.lecturefinish)
				gameState = GameState.START;
			break;

		case GameState.START:
			objectManager.StartObject ();
			uiManager.StartUI ();
			timeManager.StartTimer (playtime);

			gameState = GameState.PLAY;
			break;

		case GameState.PLAY:
			timeManager.TimeCalculate ();
			switchController.OnPlayIndicator (playerController.hitObject);
			switchController.OffPlayIndicator (playerController.hitObject);

			if (switchController.onClicked) {
				audioManager.PlayOnSwitch (); 

				if (buttonController.pcClicked) {
					audioManager.PlayOnPc ();
					uiManager.OnPc ();

					if (gold != true) {
						objectManager.AppearGoldKey ();
					} 
				} else {
					uiManager.AppearPcSwitch ();
					buttonController.PcPlayIndicator (playerController.hitObject);
				}

			} else if (switchController.offClicked) {
				audioManager.PlayOffSwitch ();
				uiManager.DisappearPcSwitch ();
			}

			if (eyeController.hasClicked) {

				if (playerController.hitObject != null)

				switch (playerController.hitObject.name) {

				case ("Red"):
					uiManager.GetRedkey ();
					red = true;
					break;
				case ("Blue"):
					uiManager.GetBluekey ();
					blue = true;
					break;
				case ("Gold"):
					uiManager.GetGoldkey ();
					gold = true;
					break;

				default:
					break;
				}
				audioManager.PlayGet ();
				objectManager.DestroyObject (playerController.hitObject);
			} 
			
			if (red == true && blue == true && gold == true) {
				
				door.DoorIndicator (playerController.hitObject);

				if (door.opendoor) {
					door.MoveDoor ();
					audioManager.PlayOpen ();
					uiManager.DoorView ();
					StartCoroutine ("wait");

				}
			} else if (timeManager.timeup) {
				gameState = GameState.TIMEUP;
			}

			break;

		case GameState.TIMEUP:
			audioManager.Main.Stop ();
			audioManager.PlayGameOver ();
			playerController.ResetPosition ();
			uiManager.TimeupUi ();
			lectureManager.TimeupTime ();
			if (lectureManager.timeupfinish) {
				gameState = GameState.INIT;
				SceneManager.LoadScene ("Start");
			}
			break;

		case GameState.CLEAR:
			SceneManager.LoadScene ("Clear");
			gameState = GameState.INIT;
			break;
		}
	}

	void InitGameManager(){
		red = false;
		blue = false;
		gold = false;
		isRunning = false;
	}

	void ResetScene(){
		if(Input.GetKeyDown(KeyCode.Q))
			SceneManager.LoadScene("Start");
	}

	IEnumerator wait (){
		if (isRunning) {
			yield break;

		} else {
			isRunning = true;
			yield return new WaitForSeconds (3);
			gameState = GameState.CLEAR;
			isRunning = false;
		}
	}
}