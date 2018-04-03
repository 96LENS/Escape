using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrearController : MonoBehaviour {

	public float interval;


	void Start() {
		StartCoroutine ("Return");
	}
		
	IEnumerator Return(){
		yield return new WaitForSeconds (interval);
		SceneManager.LoadScene ("Start");

	}
}
