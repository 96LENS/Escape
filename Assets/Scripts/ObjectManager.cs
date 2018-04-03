using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

	public GameObject LectureSphere;

	[SerializeField] private GameObject RedKey, BlueKey, GoldKey;

	public void InitObject(){
		LectureSphere.SetActive (false);
		RedKey.SetActive (false);
		BlueKey.SetActive (false);
		GoldKey.SetActive (false);
	}

	public void StartObject(){
		RedKey.SetActive (true);
		BlueKey.SetActive (true);
	}

	public void AppearSphere(){
		LectureSphere.SetActive (true);
	}

	public void AppearGoldKey (){
		GoldKey.SetActive (true);
	}

	public void DestroyObject(GameObject obj){
		Destroy (obj);
	}
}
